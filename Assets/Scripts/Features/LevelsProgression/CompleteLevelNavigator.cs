using Core.Ads.presentation.InterstitialAdNavigator;
using Core.SDK.GameState;
using Core.Sound.presentation;
using Doozy.Engine;
using Features.Levels.domain;
using Features.Levels.presentation;
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
        [Inject(Id = IInterstitialAdNavigator.DefaultInstance)] private IInterstitialAdNavigator adNavigator;
        [Inject] private CurrentLevelLoadingNavigator currentLevelLoadingNavigator;

        public void CompleteCurrentLevel()
        {
            playSoundNavigator.Play(completeLevelSound);
            
            Message.Send(levelCompletedUIEvent);
            
            completeCurrentLevelUseCase.CompleteCurrentLevel();
            gameStateNavigator.SetLevelPlayingState(false);
            adNavigator.ShowAd().Subscribe(_ =>
            {
                currentLevelLoadingNavigator.Load();
            }).AddTo(this);
        }
    }
}
