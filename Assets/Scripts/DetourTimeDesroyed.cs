using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WildBall.TrapAndLet
{
    public class DetourTimeDesroyed : MonoBehaviour
    {
        [SerializeField] private GameObject parentGameObject;
        [SerializeField] private MeshRenderer mainPlanform;
        [SerializeField, Range(1.0f, 10.0f)] private float timeLife;
        private float currentTime;
        private bool timerStart;
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.name == Inputs.GlobalStringVars.PLAYER_NAME)
            {
                timerStart = true;
            }
        }
        void Update()
        {
            if (timerStart)
            {
                Timer();
            }
        }
        private void Deactivate()
        {
            timerStart = false;
            currentTime = 0;
            mainPlanform.materials[1].color = new Color(1,0,0,0);
            parentGameObject.SetActive(false);
        }
        private void Timer()
        {
            if(currentTime < timeLife)
            {
                currentTime += Time.deltaTime;
                float albedoValue = Inputs.GlobalStringVars.ReductionOfRanges(currentTime, 0.0f, timeLife, 0, 1);
                mainPlanform.materials[1].color = new Color(1, 0, 0, albedoValue);
            }
            else
            {
                Deactivate();
            }
        }
    }
}

