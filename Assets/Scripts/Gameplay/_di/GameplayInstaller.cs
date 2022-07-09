using Gameplay.Death;
using Gameplay.Fall.presentation;
using Gameplay.Respawn;
using Levels.presentation.analytics;
using UnityEngine;
using Zenject;

namespace Gameplay._di
{
    public class GameplayInstaller: MonoInstaller
    {
        [SerializeField] private FallSettings fallSettings;
        [SerializeField] private FallNavigator fallNavigator;
        [SerializeField] private GameStateNavigator gameStateNavigator;
        [SerializeField] private RespawnNavigator respawnNavigator;
        
        public override void InstallBindings()
        {
            Container.Bind<LevelFailedAnalyticsEventUseCase>().AsSingle();
            Container.Bind<DeathNavigator>().AsSingle();
            Container.BindInstance(fallSettings).AsSingle();
            Container.BindInstance(respawnNavigator).AsSingle();
            Container.BindInstance(gameStateNavigator).AsSingle();
            Container.Bind<IFallNavigator>().FromInstance(fallNavigator).AsSingle();
        }
    }
}