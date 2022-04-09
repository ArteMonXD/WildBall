using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WildBall.Triggers
{
    public class ActivatePrompt : MonoBehaviour
    {
        [SerializeField] private Inputs.GlobalStringVars.PromtArrows promtArrows;
        [SerializeField] private Interface.ArrowsPromt arrows;
        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.name == Inputs.GlobalStringVars.PLAYER_NAME)
            {
                arrows.ActivatePromt(promtArrows);
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.name == Inputs.GlobalStringVars.PLAYER_NAME)
            {
                arrows.ActivatePromt(Inputs.GlobalStringVars.PromtArrows.None);
            }
        }
        private void OnCollisionStay(Collision collision)
        {
            if (collision.gameObject.name == Inputs.GlobalStringVars.PLAYER_NAME)
            {
                arrows.ActivatePromt(promtArrows);
            }
        }
        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.name == Inputs.GlobalStringVars.PLAYER_NAME)
            {
                arrows.ActivatePromt(Inputs.GlobalStringVars.PromtArrows.None);
            }
        }
    }
}

