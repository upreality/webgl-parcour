﻿using Features.Interaction.presentation;
using UnityEngine;
using Zenject;

namespace Features.Respawn.presentation
{
    public class LevelSpawn : MonoBehaviour
    {
        [SerializeField] private ParticlesSpawn spawn;
        [SerializeField] private bool initialSpawn;
        
        [Inject] private SpawnNavigator spawnNavigator;

        private void Start()
        {
            if (!initialSpawn) return;
            spawnNavigator.UpdateSpawn(spawn);
        }

        public void SetActiveSpawn() => spawnNavigator.UpdateSpawn(spawn);
    }
}