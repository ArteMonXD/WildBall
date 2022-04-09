using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WildBall.Triggers
{
    public class ActivateObjectViaCollision : MonoBehaviour
    {
        [SerializeField] private GameObject activateObject;

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.name == Inputs.GlobalStringVars.PLAYER_NAME)
            {
                if(activateObject != null)
                {
                    if (!activateObject.activeSelf)
                    {
                        activateObject.SetActive(true);
                    }
                }
#if UNITY_EDITOR
                else
                {
                    Debug.Log("Нет объекта");
                }
#endif
            }
        }
    }
}

