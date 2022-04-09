using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                GameOver();
            }
        }
        private void GameOver()
        {
            failedPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}

