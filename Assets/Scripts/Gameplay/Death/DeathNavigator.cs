using System;
using Ads.presentation.InterstitialAdNavigator;
using Gameplay.LevelRestart;
using Levels.presentation.analytics;
using UniRx;
using Zenject;

namespace Gameplay.Death
{
    public class DeathNavigator
    {
        [Inject] private IInterstitialAdNavigator adNavigator;
        [Inject] private RestartNavigator restartNavigator;
        [Inject] private GameStateNavigator gameStateNavigator;
        [Inject] private LevelFailedAnalyticsEventUseCase levelFailedEventUseCase;

        public IObservable<Unit> HandleDeath()
        {
            levelFailedEventUseCase.Send();
            gameStateNavigator.SetLevelPlayingState(false);
            return adNavigator.ShowAd().Do(_ => restartNavigator.Restart()).Select(_ => Unit.Default);
        }
    }
}