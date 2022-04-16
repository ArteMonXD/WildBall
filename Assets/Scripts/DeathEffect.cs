using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WildBall.Effects
{
    public class DeathEffect : MonoBehaviour
    {
        private GameObject player;
        private void Awake()
        {
            player = transform.GetComponentInParent<Inputs.PlayerInput>().gameObject;
        }
        private void OnParticleSystemStopped()
        {
            player.SetActive(false);
        }
    }
}

