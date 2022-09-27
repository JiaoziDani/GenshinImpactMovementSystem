using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GenshinImpactMovementSystem
{
    public class PlayerAirborneState : PlayerMovementState
    {
        public PlayerAirborneState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
        {
        }

        #region Reusable Methods

        protected override void OnContactWithGround(Collider collider)
        {
            stateMachine.ChangeState(stateMachine.IdlingState);
        }


        #endregion

    }
}
