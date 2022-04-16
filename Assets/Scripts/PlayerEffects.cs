using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WildBall.Effects
{
    public class PlayerEffects : MonoBehaviour
    {
        [SerializeField] private ParticleSystem deathPS;
        private MeshRenderer meshRenderer;

        private void Awake()
        {
            //deathPS = transform.GetComponentInChildren<ParticleSystem>();
            meshRenderer = GetComponent<MeshRenderer>();
        }
        public void DeathParticleSystemPlay()
        {
            meshRenderer.enabled = false;
            deathPS.Play();
        }
    }
}

