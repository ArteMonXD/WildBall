using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WildBall.TrapAndLet
{
    public class DeathRoom : MonoBehaviour
    {
        [SerializeField] private Transform[] pointAtack;
        private Animator animator;
        private int currentPoint = 0;
        [SerializeField, Range(0.0f, 10.0f)] private float speedSwitchPoint;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            Move();
        }
        public void Move()
        {
            if (transform.position != pointAtack[currentPoint].position)
            {
                transform.position = Vector3.MoveTowards(transform.position, pointAtack[currentPoint].position, speedSwitchPoint * Time.deltaTime);
            }
            else
            {
                animator.SetBool(Inputs.GlobalStringVars.DEATHCUBE_ATTACK, true);
            }
        }
        public void SwitchCurrentPosition()
        {
            animator.SetBool(Inputs.GlobalStringVars.DEATHCUBE_ATTACK, false);
            int newPoint;
            do
            {
                newPoint = Random.Range(0, pointAtack.Length);
            }
            while (currentPoint == newPoint);
            currentPoint = newPoint;
        }
    }
}

