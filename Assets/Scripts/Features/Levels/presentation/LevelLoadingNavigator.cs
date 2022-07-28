﻿using Features.Levels.domain.repositories;
using Features.Levels.presentation.loader;
using Features.Levels.presentation.respawn;
using UnityEngine;
using Zenject;

namespace Features.Levels.presentation
{
    public class LevelLoadingNavigator
    {
        [Inject] private IRespawnNavigator respawnNavigator;
        [Inject] private ILevelSceneObjectRepository repository;
        [Inject] private LevelSceneLoader loader;

        public void LoadLevel(long levelId)
        {
            Debug.Log("Load level " + levelId);
            respawnNavigator.RespawnPlayer();
            var scene = repository.GetLevelScene(levelId);
            loader.LoadLevel(scene);
        }
    }
}