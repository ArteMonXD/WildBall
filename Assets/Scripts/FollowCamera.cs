using System.Collections.Generic;
using UnityEngine;

namespace WildBall.Inputs
{
    public class FollowCamera : MonoBehaviour
    {
        [SerializeField] private Transform playerTransform;
        //private Vector3 offset;
        [SerializeField] private Dictionary<string, Vector3> offsets = new Dictionary<string, Vector3>();
        [SerializeField] private Dictionary<string, Quaternion> angles = new Dictionary<string, Quaternion>();
        [SerializeField, Range(0.0f, 1.0f)]
        private float degree = 0.095f;
        [SerializeField] private string currentState;
        [SerializeField] private bool swithState;
        [SerializeField, Range(0.0f, 10.0f)]
        private float speedSwith;
        private void Start()
        {
            Vector3 offsetBase = transform.position - playerTransform.position;
            offsets.Add(GlobalStringVars.STATES[0], offsetBase);
            offsets.Add(GlobalStringVars.STATES[1], new Vector3(offsetBase.z, offsetBase.y, offsetBase.x));
            offsets.Add(GlobalStringVars.STATES[2], new Vector3(offsetBase.x, offsetBase.y, (offsetBase.z * -1)));
            offsets.Add(GlobalStringVars.STATES[3], new Vector3((offsetBase.z * -1), offsetBase.y, offsetBase.x));
            angles.Add(GlobalStringVars.STATES[0], transform.rotation);
            angles.Add(GlobalStringVars.STATES[1], Quaternion.Euler(transform.rotation.x, 90, transform.rotation.z));
            angles.Add(GlobalStringVars.STATES[2], Quaternion.Euler(transform.rotation.x, 180, transform.rotation.z));
            angles.Add(GlobalStringVars.STATES[3], Quaternion.Euler(transform.rotation.x, -90, transform.rotation.z));
        }
        private void FixedUpdate()
        {
            SwitchCamera();
            Follow();
        }

        public void SwitchState(string state)
        {
            if (state != currentState)
            {
                swithState = true;
                currentState = state;
            }
        }
        private void Follow()
        {
            transform.position = Vector3.Lerp(transform.position, playerTransform.position + offsets[currentState], degree);
        }
        private void SwitchCamera()
        {
            if (swithState)
            {
                if (transform.position != offsets[currentState])
                {
                    transform.position = Vector3.MoveTowards(transform.position, offsets[currentState], speedSwith * Time.deltaTime);
                }
                else
                {
                    swithState = false;
                }
                if (transform.rotation != angles[currentState])
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation, angles[currentState], speedSwith);
                }
            }
        }
#if UNITY_EDITOR
        [Header("For Settings (Set Start Position)")]
        [SerializeField] private Vector3 positionRelativePlayer = new Vector3(0.0f, 1.429999f, -3.380001f);
        [SerializeField] private Vector3 rotationRelativePlayer = new Vector3(21.16f, 0.0f, 0.0f);
        [ContextMenu("Set Start Position")]
        public void SetStartPosition()
        {
            if (playerTransform == null)
            {
                Debug.Log("First, add a player to the \"Player Transform\" field");
            }
            else
            {
                transform.SetParent(playerTransform);
                transform.localPosition = positionRelativePlayer;
                transform.localRotation = Quaternion.Euler(rotationRelativePlayer);
                transform.SetParent(null);
            }
        }
#endif
    }
}

