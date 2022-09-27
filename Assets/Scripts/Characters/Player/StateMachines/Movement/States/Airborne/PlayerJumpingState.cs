using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GenshinImpactMovementSystem
{
    public class PlayerJumpingState : PlayerAirborneState
    {
        public PlayerJumpingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
        {
        }

        #region IState Methods

        public override void Enter()
        {
            base.Enter();
            
            stateMachine.ReusableData.MovementSpeedModifier = 0f;

            Jump();
        }

        #endregion

        #region Main Methods

        private void Jump()
        {
            Vector3 jumpForce = stateMachine.ReusableData.CurrentJumpForce;

            Vector3 playerForward = stateMachine.Player.transform.forward;

            jumpForce.x *= playerForward.x;
            jumpForce.z *= playerForward.z;

            ResetVelocity();

            stateMachine.Player.Rigidbody.AddForce(jumpForce, ForceMode.VelocityChange);
        }

        #endregion
    }
}
