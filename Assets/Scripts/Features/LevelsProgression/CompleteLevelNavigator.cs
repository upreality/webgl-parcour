using Core.Ads.presentation.InterstitialAdNavigator;
using Core.SDK.GameState;
using Core.Sound.presentation;
using Doozy.Engine;
using Features.Levels.domain;
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

        public void CompleteCurrentLevel()
        {
            playSoundNavigator.Play(completeLevelSound);
            
            completeCurrentLevelUseCase.CompleteCurrentLevel();
            gameStateNavigator.SetLevelPlayingState(false);
            adNavigator.ShowAd().Subscribe(_ =>
                GameEventMessage.SendEvent(levelCompletedUIEvent)
            ).AddTo(this);
        }
    }
}