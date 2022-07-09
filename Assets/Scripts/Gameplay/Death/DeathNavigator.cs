using System;
using Ads.presentation.InterstitialAdNavigator;
using Gameplay.Respawn;
using Levels.presentation.analytics;
using UniRx;
using Zenject;
using static Ads.presentation.InterstitialAdNavigator.IInterstitialAdNavigator;

namespace Gameplay.Death
{
    public class DeathNavigator
    {
        [Inject] private IInterstitialAdNavigator adNavigator;

        [Inject] private RespawnNavigator respawnNavigator;
        [Inject] private GameStateNavigator gameStateNavigator;
        [Inject] private LevelFailedAnalyticsEventUseCase levelFailedEventUseCase;

        public IObservable<Unit> HandleDeath()
        {
            levelFailedEventUseCase.Send();
            gameStateNavigator.SetLevelPlayingState(false);
            return adNavigator.ShowAd().Do(_ => respawnNavigator.Respawn()).Select(_ => Unit.Default);
        }
    }
}