using Core.SDK.GameState;
using Features.Levels.presentation;
using Features.Levels.presentation.respawn;
using Features.LevelTime.domain;
using UniRx;
using UnityEngine;
using Zenject;

namespace Features.LevelTime.presentation
{
    public class LevelTimerHandler : MonoBehaviour
    {
        [Inject] private GameStateNavigator gameStateNavigator;
        [Inject] private LevelLoadingNavigator levelLoadingNavigator;
        [Inject] private ILevelTimerRepository levelTimerRepository;
        [Inject] private IRespawnNavigator respawnNavigator;

        private void Start()
        {
            levelTimerRepository.StartTimer();
            
            gameStateNavigator
                .GetGameState()
                .Select(state => state == GameState.Active)
                .Subscribe(active =>
                    levelTimerRepository.SetPaused(!active)
                ).AddTo(this);

            levelLoadingNavigator.OnLevelLoaded += () => levelTimerRepository.StartTimer();
        }
    }
}