using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WildBall.Interface
{
    public class ArrowsPromt : MonoBehaviour
    {
        [SerializeField] private GameObject[] arrows;
        public void ActivatePromt(Inputs.GlobalStringVars.PromtArrows promtArrows)
        {
            switch (promtArrows)
            {
                case Inputs.GlobalStringVars.PromtArrows.Left:
                    arrows[0].SetActive(true);
                    arrows[1].SetActive(false);
                    arrows[2].SetActive(false);
                    arrows[3].SetActive(false);
                    break;
                case Inputs.GlobalStringVars.PromtArrows.Top:
                    arrows[0].SetActive(false);
                    arrows[1].SetActive(true);
                    arrows[2].SetActive(false);
                    arrows[3].SetActive(false);
                    break;
                case Inputs.GlobalStringVars.PromtArrows.Right:
                    arrows[0].SetActive(false);
                    arrows[1].SetActive(false);
                    arrows[2].SetActive(true);
                    arrows[3].SetActive(false);
                    break;
                case Inputs.GlobalStringVars.PromtArrows.Buttom:
                    arrows[0].SetActive(false);
                    arrows[1].SetActive(false);
                    arrows[2].SetActive(false);
                    arrows[3].SetActive(true);
                    break;
                case Inputs.GlobalStringVars.PromtArrows.None:
                    arrows[0].SetActive(false);
                    arrows[1].SetActive(false);
                    arrows[2].SetActive(false);
                    arrows[3].SetActive(false);
                    break;
            }
        }
    }
}

