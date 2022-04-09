using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WildBall.TrapAndLet
{
    public class PlatformWithTrap : MonoBehaviour
    {
        private Vector3[] trapPositions = { new Vector3(-1.25f, 0.01f, -1.25f),
                                        new Vector3(1.25f, 0.01f, -1.25f),
                                        new Vector3(-1.25f, 0.01f, 1.25f),
                                        new Vector3(1.25f, 0.01f, 1.25f)};
        [SerializeField] private GameObject trap;
        private void Awake()
        {
            trap.transform.localPosition = trapPositions[Random.Range(0, trapPositions.Length)];
        }
        public void Activate()
        {
            trap.gameObject.GetComponent<Animator>().SetTrigger(Inputs.GlobalStringVars.INTERACT_OBJECT_ANIMATOR_TRIGGER_NAME);
        }
    }
}

