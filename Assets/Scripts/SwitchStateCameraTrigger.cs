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
        private void Start()
        {
            player = FindObjectOfType<Inputs.PlayerInput>().transform;
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
                        playerInput.SwitchMovementState(Inputs.GlobalStringVars.STATES[0]);
                        break;
                    case Direction.Left:
                        playerInput.SwitchMovementState(Inputs.GlobalStringVars.STATES[1]);
                        break;
                    case Direction.Front:
                        playerInput.SwitchMovementState(Inputs.GlobalStringVars.STATES[2]);
                        break;
                    case Direction.Right:
                        playerInput.SwitchMovementState(Inputs.GlobalStringVars.STATES[3]);
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

