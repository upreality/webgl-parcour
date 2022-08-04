using Features.Levels.domain.repositories;
using Doozy.Engine;
using Features.Levels.domain.model;
using UnityEngine;
using Zenject;

namespace Features.Levels.presentation
{
    public class CurrentLevelLoadingNavigator : MonoBehaviour
    {
        [Inject] private ICurrentLevelRepository currentLevelRepository;
        [Inject] private LevelLoadingNavigator levelLoadingNavigator;
        [SerializeField] private string levelLoadedUIEvent = "LevelLoaded";

        private void Awake() => LoadCurrent();

        public void LoadCurrent() => LoadLevel(currentLevelRepository.GetCurrentLevel());

        public void LoadPrevious() => LoadLevel(currentLevelRepository.GetPrevLevel());

        private void LoadLevel(Level level)
        {
            levelLoadingNavigator.LoadLevel(level.ID);
            GameEventMessage.SendEvent(levelLoadedUIEvent);
        }
    }
}
