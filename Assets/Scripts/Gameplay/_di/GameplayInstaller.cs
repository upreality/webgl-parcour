using Gameplay.AttackAreas;
using Gameplay.Death;
using Gameplay.Enemies;
using Gameplay.Fall.presentation;
using Gameplay.Lever;
using Levels.presentation.analytics;
using Respawn.presentation;
using UnityEngine;
using Zenject;

namespace Gameplay._di
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] private FallSettings fallSettings;
        [SerializeField] private FallNavigator fallNavigator;
        [SerializeField] private RespawnNavigator respawnNavigator;
        [SerializeField] private CompleteLevelNavigator completeLevelNavigator;
        [SerializeField] private LeverStateNavigator leverStateNavigator;

        public override void InstallBindings()
        {
            Container.Bind<LevelFailedAnalyticsEventUseCase>().AsSingle();
            Container.Bind<IDeathCounterRepository>().To<DeathCounterDefaultRepository>().AsSingle();
            Container.Bind<DeathNavigator>().AsSingle();
            Container.Bind<AttackAreaNavigator>().AsSingle();
            Container.BindInstance(fallSettings).AsSingle();
            Container.BindInstance(respawnNavigator).AsSingle();
            Container.Bind<IFallNavigator>().FromInstance(fallNavigator).AsSingle();
            Container.BindInstance(completeLevelNavigator).AsSingle();
            Container.BindInstance(leverStateNavigator).AsSingle();
        }
    }
}