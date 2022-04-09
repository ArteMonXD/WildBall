using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace WildBall.Triggers
{
    public class ObjectInteractionTrigger : MonoBehaviour
    {
        private enum AnimationPlayed { Normal, Other};
        [SerializeField] private AnimationPlayed animationPlayed;
        [SerializeField] private Text hintText;
        private Animator animatorInteractObject;
        [SerializeField] private Animator[] additionalLaunchObjects;
        [SerializeField] private float delayTime;

        private void Awake()
        {
            animatorInteractObject = transform.parent.gameObject.GetComponent<Animator>();
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.name == Inputs.GlobalStringVars.PLAYER_NAME)
            {
                hintText.text = "Press the \"E\" button to interact";
            }
        }
        private void OnTriggerStay(Collider other)
        {
            if(other.gameObject.name == Inputs.GlobalStringVars.PLAYER_NAME)
            {
                if (Input.GetButtonUp(Inputs.GlobalStringVars.INTERACT_BUTTON))
                {
                    switch (animationPlayed)
                    {
                        case AnimationPlayed.Normal:
                            animatorInteractObject.SetTrigger(Inputs.GlobalStringVars.INTERACT_OBJECT_ANIMATOR_TRIGGER_NAME);
                            break;
                        case AnimationPlayed.Other:
                            animatorInteractObject.SetTrigger(Inputs.GlobalStringVars.LIFT_HIGHT_UP_TRIGGER_NAME);
                            break;
                    }
                    
                    if(additionalLaunchObjects.Length > 0)
                    {
                        foreach(Animator _animator in additionalLaunchObjects)
                        {
                            StartCoroutine(StartAdditionalObject(_animator));
                        }
                    }
                }
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.name == Inputs.GlobalStringVars.PLAYER_NAME)
            {
                hintText.text = "";
            }
        }
        private IEnumerator StartAdditionalObject(Animator animator)
        {
            yield return new WaitForSeconds(delayTime);

            animator.SetTrigger(Inputs.GlobalStringVars.INTERACT_OBJECT_ANIMATOR_TRIGGER_NAME);
        }
    }
}

