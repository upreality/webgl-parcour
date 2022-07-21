using Features.Gameplay.AttackAreas;
using Features.Gameplay.Death;
using Features.Gameplay.Fall.presentation;
using Features.Gameplay.Lever;
using Features.Levels.presentation.analytics;
using Features.LevelsProgression;
using Features.Respawn.presentation;
using UnityEngine;
using Zenject;

namespace Features.Gameplay._di
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