using Levels.domain.repositories;
using UnityEngine;
using Zenject;

namespace Levels.presentation
{
    public class CurrentLevelLoadingNavigator : MonoBehaviour
    {
        [Inject] private ICurrentLevelRepository currentLevelRepository;
        [Inject] private LevelLoadingNavigator levelLoadingNavigator;

        private void Awake() => Load();

        public void Load()
        {
            var currentLevel = currentLevelRepository.GetCurrentLevel();
            levelLoadingNavigator.LoadLevel(currentLevel.ID);
        }
    }
}
