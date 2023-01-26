using UnityEngine;

namespace WildBall.Inputs
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField, Range(0f, 10f)] private float speed = 2.0f;
        private bool speedBuff;
        private float speedBuffMultipiler;
        private Rigidbody playerRigidbody;
        private Vector3 saveVelocity;
        private Vector3 saveAngularVelocity;
        private void Awake()
        {
            playerRigidbody = GetComponent<Rigidbody>();
        }

        public void MoveCharacter(Vector3 movement)
        {
            if (!speedBuff)
                playerRigidbody.AddForce(movement * speed);
            else
                playerRigidbody.AddForce(movement * speed * speedBuffMultipiler);
        }

        public void Freeze(bool status)
        {
            if (status)
            {
                saveVelocity = playerRigidbody.velocity;
                saveAngularVelocity = playerRigidbody.angularVelocity;
                playerRigidbody.constraints = RigidbodyConstraints.FreezeAll;
            }
            else
            {
                playerRigidbody.constraints = RigidbodyConstraints.None;
                playerRigidbody.velocity = saveVelocity;
                playerRigidbody.angularVelocity = saveAngularVelocity;
            }
                
        }

        public void ActiveSpeedBuff(float _speedBuffMultipiler, bool status)
        {
            speedBuffMultipiler = _speedBuffMultipiler;
            speedBuff = status;
        }
#if UNITY_EDITOR
        [ContextMenu("Reset values")]
        public void ResetValues()
        {
            speed = 2.0f;
        }
#endif
    }
}
