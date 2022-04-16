using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WildBall.Effects;

namespace WildBall.Triggers 
{
    public class GameOverTrigger : MonoBehaviour
    {
        [SerializeField] private GameObject failedPanel;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.name == Inputs.GlobalStringVars.PLAYER_NAME)
            {
                //StartCoroutine(GameOver());
                GameOver(other.GetComponent<PlayerEffects>());
            }
        }
        /*
        private IEnumerator GameOver()
        {
            yield return new WaitForSecondsRealtime(1);

            failedPanel.SetActive(true);
            Time.timeScale = 0;
        }
        */
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
