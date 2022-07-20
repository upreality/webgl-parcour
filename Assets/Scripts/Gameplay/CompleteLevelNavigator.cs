using Ads.presentation.InterstitialAdNavigator;
using Doozy.Engine;
using Levels.domain;
using Levels.presentation;
using SDK.GameState;
using Sound.presentation;
using UniRx;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class CompleteLevelNavigator : MonoBehaviour
    {
        [SerializeField] private FirstPersonLook look;
        [SerializeField] private FirstPersonMovement movement;
        [SerializeField] private AudioClip completeLevelSound;
        [SerializeField] private string levelCompletedUIEvent = "LevelCompleted";

        [Inject] private CompleteCurrentLevelUseCase completeCurrentLevelUseCase;
        [Inject] private GameStateNavigator gameStateNavigator;
        [Inject] private PlaySoundNavigator playSoundNavigator;
        [Inject(Id = IInterstitialAdNavigator.DefaultInstance)] private IInterstitialAdNavigator adNavigator;
        [Inject] private CurrentLevelLoadingNavigator currentLevelLoadingNavigator;

        public void CompleteCurrentLevel()
        {
            movement.ResetVelocity();
            movement.enabled = false;
            look.enabled = false;

            playSoundNavigator.Play(completeLevelSound);
            
            Message.Send(levelCompletedUIEvent);
            
            completeCurrentLevelUseCase.CompleteCurrentLevel();
            gameStateNavigator.SetLevelPlayingState(false);
            adNavigator.ShowAd().Subscribe(_ =>
            {
                // currentLevelLoadingNavigator.Load();
                movement.enabled = true;
                look.enabled = true;
            }).AddTo(this);
        }
    }
}