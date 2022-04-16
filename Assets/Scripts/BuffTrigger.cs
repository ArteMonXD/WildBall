using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WildBall.Effects
{
    public class BuffTrigger : MonoBehaviour
    {
        [SerializeField] private GameObject particleSystemBuff;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.name == Inputs.GlobalStringVars.PLAYER_NAME)
            {
                if (!particleSystemBuff.activeSelf)
                {
                    particleSystemBuff.SetActive(true);
                }
            }
        }
    }
}