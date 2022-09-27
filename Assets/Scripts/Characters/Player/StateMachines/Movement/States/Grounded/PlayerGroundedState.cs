using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GenshinImpactMovementSystem
{
    public class PlayerGroundedState : PlayerMovementState
    {   
        private SlopeData slopeData;
        
        public PlayerGroundedState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
        {
            slopeData = stateMachine.Player.ColliderUtility.SlopeData;
        }
        
        #region  IState Methods

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            Float();
        }
        #endregion

        #region Main Methods

        private void Float()
        {
            Vector3 capsuleColliderCenterInWorldSpace = stateMachine.Player.ColliderUtility.CapsuleColliderData.Collider.bounds.center;

            Ray downwardsRayFromCapsuleCenter = new Ray(capsuleColliderCenterInWorldSpace, Vector3.down);

            if (Physics.Raycast(downwardsRayFromCapsuleCenter, out RaycastHit hit, slopeData.FloatRayDistance, stateMachine.Player.LayerData.GroundLayer, QueryTriggerInteraction.Ignore))
            {   
                float groundAngle = Vector3.Angle(hit.normal, -downwardsRayFromCapsuleCenter.direction);
                
                float slopeSpeedModifier = SetSlopeSpeedModifierOnAngle(groundAngle);

                if (slopeSpeedModifier == 0f)
                {
                    return;
                }

                float distanceToFloatingPoint = stateMachine.Player.ColliderUtility.CapsuleColliderData.ColliderCenterInLocalSpace.y * stateMachine.Player.transform.localScale.y - hit.distance;

                if (distanceToFloatingPoint == 0f)
                {
                    return; 
                }

                float amountToLift = distanceToFloatingPoint * slopeData.StepReachForce - GetPlayerVerticalVelocity().y;
                
                Vector3 lifeForce = new Vector3(0f, amountToLift, 0f);

                stateMachine.Player.Rigidbody.AddForce(lifeForce, ForceMode.VelocityChange);
            }
        }

        private float SetSlopeSpeedModifierOnAngle(float angle)
        {
            float slopeSpeedModifier = movementData.SlopeSpeedAngles.Evaluate(angle);

            stateMachine.ReusableData.MovementOnSlopeSpeedModifier = slopeSpeedModifier;

            return slopeSpeedModifier;
        }

        #endregion

        #region Reusable Methods

        protected override void AddInputActionsCallbacks()
        {
            base.AddInputActionsCallbacks();

            stateMachine.Player.Input.PlayerActions.Movement.canceled += OnMovementCanceled; 

            stateMachine.Player.Input.PlayerActions.Dash.started += OnDashStarted; 

            stateMachine.Player.Input.PlayerActions.Jump.started += OnJumpStarted;
        }

        protected override void RemoveInputActionsCallbacks()
        {
            base.RemoveInputActionsCallbacks();

            stateMachine.Player.Input.PlayerActions.Movement.canceled -= OnMovementCanceled; 

            stateMachine.Player.Input.PlayerActions.Dash.started -= OnDashStarted; 

            stateMachine.Player.Input.PlayerActions.Jump.started -= OnJumpStarted;
        }

        protected virtual void OnMove()
        {
            if (stateMachine.ReusableData.ShouldWalk)
            {
                stateMachine.ChangeState(stateMachine.WalkingState);
                
                return;
            }

            stateMachine.ChangeState(stateMachine.RunningState);
        }

        #endregion

        #region Input Methods

        protected virtual void OnMovementCanceled(InputAction.CallbackContext context)
        {
           stateMachine.ChangeState(stateMachine.IdlingState);
        }

        protected virtual void OnDashStarted(InputAction.CallbackContext context)
        {
            stateMachine.ChangeState(stateMachine.DashingState);
        }

        protected virtual void OnJumpStarted(InputAction.CallbackContext context)
        {
            stateMachine.ChangeState(stateMachine.JumpingState);
        }

        #endregion
        
    }
}
