using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WildBall.Triggers
{
    public class DiactivateObjectViaCollision : MonoBehaviour
    {
        [SerializeField] private GameObject diactivateObject;
        [SerializeField] private GameObject[] activateObject;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.name == Inputs.GlobalStringVars.PLAYER_NAME)
            {
                if(diactivateObject)
                {
                    if (diactivateObject.activeSelf)
                    {
                        diactivateObject.SetActive(false);
                    }
                }
                foreach (GameObject activateGO in activateObject)
                {
                    if (!activateGO.activeSelf)
                    {
                        activateGO.SetActive(true);
                    }
                }
            }    
        }
    }
}
