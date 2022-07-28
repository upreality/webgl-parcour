using System;
using Core.Ads.presentation.InterstitialAdNavigator;
using Core.SDK.GameState;
using Features.Levels.presentation.analytics;
using Features.Levels.presentation.respawn;
using UniRx;
using Zenject;

namespace Features.Death
{
    public class DeathNavigator
    {
        [Inject(Id = IInterstitialAdNavigator.DefaultInstance)] private IInterstitialAdNavigator adNavigator;

        [Inject] private IRespawnNavigator respawnNavigator;
        [Inject] private IDeathCounterRepository deathCounter;
        [Inject] private GameStateNavigator gameStateNavigator;
        [Inject] private LevelFailedAnalyticsEventUseCase levelFailedEventUseCase;

        public IObservable<Unit> HandleDeath()
        {
            levelFailedEventUseCase.Send();
            gameStateNavigator.SetLevelPlayingState(false);
            deathCounter.CountDeath();
            return adNavigator.ShowAd().Do(_ => respawnNavigator.RespawnPlayer()).Select(_ => Unit.Default);
        }
    }
}