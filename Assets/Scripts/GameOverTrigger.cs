using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                GameOver();
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
        private void GameOver()
        {
            failedPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
