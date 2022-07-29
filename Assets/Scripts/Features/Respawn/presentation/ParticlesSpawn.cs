using System;
using UnityEngine;

namespace Features.Respawn.presentation
{
    [Serializable]
    public class ParticlesSpawn : SpawnNavigator.ISpawn
    {
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private GameObject mark;
        [SerializeField] private ParticleSystem burst;
        [SerializeField] private ParticleSystem activeParticles;

        public Transform GetPoint() => spawnPoint;

        public void SetSelected(bool state)
        {
            activeParticles.gameObject.SetActive(state);
            // if (state) activeParticles.Play();
            // else activeParticles.Stop();
            
            mark.SetActive(!state);
        }

        public void Activate() => burst.Play();
    }
}