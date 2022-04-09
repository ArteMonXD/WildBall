using UnityEngine;

namespace WildBall.Inputs
{
    [RequireComponent(typeof(PlayerMovement))]
    public class PlayerInput : MonoBehaviour
    {
        private Vector3 movement;
        private PlayerMovement playerMovement;
        private void Awake()
        {
            playerMovement = GetComponent<PlayerMovement>();
        }
        void Update()
        {
            float horizontal = Input.GetAxis(GlobalStringVars.HORIZONTAL_AXIS);
            float vertical = Input.GetAxis(GlobalStringVars.VERTICAL_AXIS);

            movement = new Vector3(horizontal, 0, vertical).normalized;
        }
        private void FixedUpdate()
        {
            playerMovement.MoveCharacter(movement);
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
