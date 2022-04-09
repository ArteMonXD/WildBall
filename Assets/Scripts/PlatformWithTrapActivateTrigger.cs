using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WildBall.Triggers
{
    public class PlatformWithTrapActivateTrigger : MonoBehaviour
    {
        private TrapAndLet.PlatformWithTrap platformTrap;
        private void Awake()
        {
            platformTrap = GetComponentInParent<TrapAndLet.PlatformWithTrap>();
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.name == Inputs.GlobalStringVars.PLAYER_NAME)
            {
                platformTrap.Activate();
            }
    }
    }
}

