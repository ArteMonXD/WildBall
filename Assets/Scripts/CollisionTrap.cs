using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WildBall.Effects;

namespace WildBall.Triggers
{
    public class CollisionTrap : MonoBehaviour
    {
        [SerializeField] private GameObject failedPanel;
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.name == Inputs.GlobalStringVars.PLAYER_NAME)
            {
                //StartCoroutine(GameOver());
                GameOver(collision.gameObject.GetComponent<PlayerEffects>());
            }
        }
        private void GameOver(PlayerEffects playerEffects)
        {
            failedPanel.SetActive(true);
            playerEffects.DeathParticleSystemPlay();
            Time.timeScale = 0;
        }

        private IEnumerator WaitDeathEffect(ParticleSystem deathEffect)
        {
            while (!deathEffect.isStopped)
            {
                yield return null;
            }

            Time.timeScale = 0;
        }
    }
}

