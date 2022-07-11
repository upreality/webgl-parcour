using System;
using Ads.presentation.InterstitialAdNavigator;
using Levels.presentation.analytics;
using Levels.presentation.respawn;
using SDK.GameState;
using UniRx;
using Zenject;

namespace Gameplay.Death
{
    public class DeathNavigator
    {
        [Inject(Id = IInterstitialAdNavigator.DefaultInstance)] private IInterstitialAdNavigator adNavigator;

        [Inject] private IRespawnNavigator respawnNavigator;
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