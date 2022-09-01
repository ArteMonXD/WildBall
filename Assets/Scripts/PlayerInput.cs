using System.Collections.Generic;
using UnityEngine;

namespace WildBall.Inputs
{
    [RequireComponent(typeof(PlayerMovement))]
    public class PlayerInput : MonoBehaviour
    {
        private Vector3 movement;
        private PlayerMovement playerMovement;
        [SerializeField] private int movementStateCurrent;
        [SerializeField] private Dictionary<string, int> states = new Dictionary<string, int>();
        private void Awake()
        {
            playerMovement = GetComponent<PlayerMovement>();
            for (int i = 0; i<GlobalStringVars.STATES.Length; i++)
            {
                states.Add(GlobalStringVars.STATES[i], i);
            }
        }
        void Update()
        {
            float horizontal = Input.GetAxis(GlobalStringVars.HORIZONTAL_AXIS);
            float vertical = Input.GetAxis(GlobalStringVars.VERTICAL_AXIS);

            movement = CalculateMovement(horizontal, vertical);
        }
        private void FixedUpdate()
        {
            playerMovement.MoveCharacter(movement);
        }
        public void SwitchMovementState(string state)
        {
            movementStateCurrent = states[state];
        }
        private Vector3 CalculateMovement(float hor, float ver)
        {
            switch (movementStateCurrent)
            {
                case 0:
                    return new Vector3(hor, 0, ver).normalized;
                case 1:
                    return new Vector3(ver, 0, -hor).normalized;
                case 2:
                    return new Vector3(-hor, 0, -ver).normalized;
                case 3:
                    return new Vector3(-ver, 0, hor).normalized;
            }
            return Vector3.zero;
        }
#if UNITY_EDITOR
        [ContextMenu("Set Corect Name")]
        public void SetCorectName()
        {
            gameObject.name = GlobalStringVars.PLAYER_NAME;
        }
        [ContextMenu("Teleport To Finish")]
        public void TeleportToFinish()
        {
            Transform finishTrigger = FindObjectOfType<Triggers.FinishTrigger>().transform;
            transform.position = finishTrigger.position + (2 * Vector3.back);
        }
#endif
    }
}
