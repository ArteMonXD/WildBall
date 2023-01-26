using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WildBall.Triggers
{
    public class BuffTrigger : MonoBehaviour
    {
        [SerializeField] private GameObject particleSystemBuff;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.name == Inputs.GlobalStringVars.PLAYER_NAME)
            {
                Effects.PlayerBuffSystem playerBuffSystem = other.gameObject.GetComponent<Effects.PlayerBuffSystem>();
                playerBuffSystem.BuffActivate();
                if (!particleSystemBuff.activeSelf)
                {
                    particleSystemBuff.SetActive(true);
                }
                StartCoroutine(DestroyBuff());
            }
        }

        private IEnumerator DestroyBuff()
        {
            yield return new WaitForSeconds(1.5f);
            gameObject.SetActive(false);
        }
    }
}