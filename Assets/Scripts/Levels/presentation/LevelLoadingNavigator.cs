using Levels.domain.repositories;
using Levels.presentation.loader;
using Levels.presentation.respawn;
using UnityEngine;
using Zenject;

namespace Levels.presentation
{
    public class LevelLoadingNavigator
    {
        [Inject] private IRespawnNavigator respawnNavigator;
        [Inject] private ILevelSceneObjectRepository repository;
        [Inject] private LevelSceneLoader loader;

        public void LoadLevel(long levelId)
        {
            Debug.Log("Load level " + levelId);
            respawnNavigator.Respawn();
            var scene = repository.GetLevelScene(levelId);
            loader.LoadLevel(scene);
        }
    }
}