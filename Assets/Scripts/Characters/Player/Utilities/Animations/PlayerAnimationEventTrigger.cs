using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GenshinImpactMovementSystem
{
    public class PlayerAnimationEventTrigger : MonoBehaviour
    {
        private Player player;

        private void Awake() {
            player = transform.parent.GetComponent<Player>();
        }

        public void TriggerOnMovementStateAnimationEnterEvent()
        {
            player.OnMovementStateAnimationEnterEvent();
        }

        public void TriggerOnMovementStateAnimationExitEvent()
        {
            player.OnMovementStateAnimationExitEvent();
        }

        public void TriggerOnMovementStateAnimationTransitionEvent()
        {
            player.OnMovementStateAnimationTransitionEvent();
        }
    }
}
