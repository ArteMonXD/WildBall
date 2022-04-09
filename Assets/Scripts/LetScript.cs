using UnityEngine;

namespace WildBall.TrapAndLet
{
    public class LetScript : MonoBehaviour
    {
        private Animator animator;
        [SerializeField] private int currentState = 0;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        public void EndAnimationEvent()
        {
            int _state = Random.Range(0, 3);
            if (_state == currentState)
                return;
            else
            {
                animator.SetInteger(Inputs.GlobalStringVars.LET_STATE_PARAMETER, _state);
                currentState = _state;
            }

        }
    }
}

