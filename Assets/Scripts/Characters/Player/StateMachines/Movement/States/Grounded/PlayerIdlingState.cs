using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GenshinImpactMovementSystem
{
    public class PlayerIdlingState : PlayerGroundedState
    {
        public PlayerIdlingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
        {
        }

        #region IState Methods

        public override void Enter()
        {
            base.Enter();

            stateMachine.ReusableData.MovementSpeedModifier = 0f;

            stateMachine.ReusableData.CurrentJumpForce = airborneData.JumpData.StationaryForce;

            ResetVelocity();
        }

        public override void Update()
        {
            base.Update();

            if(stateMachine.ReusableData.MovementInput == Vector2.zero)
            {
                return;
            }

            OnMove();
        }

        #endregion
    }
}
