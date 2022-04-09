using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WildBall.Triggers
{
    public class ActivateTrigger : MonoBehaviour
    {
        [SerializeField] private GameObject activateObject;
        [SerializeField] private GameObject delayActivatedObject;
        [SerializeField, Range(0.0f, 10.0f)] private float delayTime;
        Coroutine currentCoroutine;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.name == Inputs.GlobalStringVars.PLAYER_NAME)
            {
                if (!activateObject.activeSelf)
                {
                    activateObject.SetActive(true);
                }
                if (delayActivatedObject != null)
                {
                    if (!delayActivatedObject.activeSelf)
                    {
                        currentCoroutine = StartCoroutine(DelayActivate());
                    }
                }
            }
        }
        private IEnumerator DelayActivate()
        {
            yield return new WaitForSeconds(delayTime);

            delayActivatedObject.SetActive(true);
            StopCoroutine(currentCoroutine);
        }
    }
}

