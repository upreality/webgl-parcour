using Core.Ads.presentation.InterstitialAdNavigator;
using Core.SDK.GameState;
using Core.Sound.presentation;
using Doozy.Engine;
using Features.Levels.domain;
using Features.LevelsProgression.LevelTime.domain;
using UniRx;
using UnityEngine;
using Zenject;

namespace Features.LevelsProgression
{
    public class CompleteLevelNavigator : MonoBehaviour
    {
        [SerializeField] private AudioClip completeLevelSound;
        [SerializeField] private string levelCompletedUIEvent = "LevelCompleted";

        [Inject] private CompleteCurrentLevelUseCase completeCurrentLevelUseCase;
        [Inject] private GameStateNavigator gameStateNavigator;
        [Inject] private PlaySoundNavigator playSoundNavigator;

        [Inject(Id = IInterstitialAdNavigator.DefaultInstance)]
        private IInterstitialAdNavigator adNavigator;
        
        [Inject] private ILevelTimerRepository levelTimerRepository;

        public void CompleteCurrentLevel()
        {
            playSoundNavigator.Play(completeLevelSound);
            gameStateNavigator.SetLevelPlayingState(false);
            levelTimerRepository.StopTimer();
            completeCurrentLevelUseCase
                .CompleteCurrentLevel()
                .Subscribe(_ => OnLevelCompleted())
                .AddTo(this);
        }

        private void OnLevelCompleted()
        {
            adNavigator
                .ShowAd()
                .Subscribe(_ => GameEventMessage.SendEvent(levelCompletedUIEvent))
                .AddTo(this);
        }
    }
}