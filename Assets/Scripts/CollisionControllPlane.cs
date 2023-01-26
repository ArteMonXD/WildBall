using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WildBall.Triggers
{
    public class CollisionControllPlane : MonoBehaviour
    {
        [SerializeField] private Transform controlledPlane;
        [SerializeField] private float roatateAngle;
        [SerializeField] private bool rotate;
        [SerializeField] private float timeRotate;
        private Quaternion resultRotate;
        [SerializeField] private Vector3 resultRotateEuler;
        private float state;
        private float currentTime;

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.name == Inputs.GlobalStringVars.PLAYER_NAME && !rotate)
            {
                resultRotateEuler = resultRotate.eulerAngles;
                resultRotate = Quaternion.Euler(controlledPlane.rotation.eulerAngles.x, controlledPlane.rotation.eulerAngles.y + roatateAngle, controlledPlane.rotation.eulerAngles.z);
                resultRotateEuler = resultRotate.eulerAngles;
                rotate = true;
            }
        }

        private void Update()
        {
            if (rotate)
            {
                Timer();
                controlledPlane.rotation = Quaternion.Slerp(controlledPlane.rotation, resultRotate, state);

                if(controlledPlane.rotation.eulerAngles == resultRotate.eulerAngles)
                {
                    state = 0.0f;
                    currentTime = 0.0f;
                    rotate = false;
                }
            }
        }

        private void Timer()
        {
            if(currentTime <= timeRotate)
            {
                currentTime += Time.deltaTime;
                state = (currentTime - 0.0f) / (timeRotate - 0.0f) * (1.0f - 0.0f) + 0.0f;
            }
        }
    }
}

