using Features.Levels.domain.repositories;
using Doozy.Engine;
using UnityEngine;
using Zenject;

namespace Features.Levels.presentation
{
    public class CurrentLevelLoadingNavigator : MonoBehaviour
    {
        [Inject] private ICurrentLevelRepository currentLevelRepository;
        [Inject] private LevelLoadingNavigator levelLoadingNavigator;
        [SerializeField] private string levelLoadedUIEvent = "LevelLoaded";

        private void Awake() => Load();

        public void Load()
        {
            var currentLevel = currentLevelRepository.GetCurrentLevel();
            levelLoadingNavigator.LoadLevel(currentLevel.ID);
            GameEventMessage.SendEvent(levelLoadedUIEvent);
        }
    }
}
