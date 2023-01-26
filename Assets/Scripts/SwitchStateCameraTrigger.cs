using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WildBall.Triggers
{
    public class SwitchStateCameraTrigger : MonoBehaviour
    {
        private enum Direction {Back, Left, Front, Right };
        private enum ControlAxis {X, Z}
        [SerializeField] private Direction direction;
        [SerializeField] private ControlAxis controlAxis;
        private Transform player;
        private Inputs.FollowCamera followCamera;
        private void Start()
        {
            player = FindObjectOfType<Inputs.PlayerInput>().transform;
            followCamera = Camera.main.GetComponent<Inputs.FollowCamera>();
        }
        private void Update()
        {
            SwitchDirection();
        }
        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.name == Inputs.GlobalStringVars.PLAYER_NAME)
            {
                Inputs.PlayerInput playerInput = other.gameObject.GetComponent<Inputs.PlayerInput>();
                switch (direction)
                {
                    case Direction.Back:
                        followCamera.SwitchState(0);
                        break;
                    case Direction.Left:
                        followCamera.SwitchState(1);
                        break;
                    case Direction.Front:
                        followCamera.SwitchState(2);
                        break;
                    case Direction.Right:
                        followCamera.SwitchState(3);
                        break;
                }
            }
        }

        private void SwitchDirection()
        {
            if (controlAxis == ControlAxis.X)
            {
                if (player.position.x < transform.position.x)
                {
                    direction = Direction.Left;
                }
                else if (player.position.x > transform.position.x)
                {
                    direction = Direction.Right;
                }
            }
            else if (controlAxis == ControlAxis.Z)
            {
                if (player.position.z < transform.position.z)
                {
                    direction = Direction.Back;
                }
                else if (player.position.z > transform.position.z)
                {
                    direction = Direction.Front;
                }
            }
        }
    }
}

