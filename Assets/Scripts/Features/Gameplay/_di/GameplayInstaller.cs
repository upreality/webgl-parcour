using Features.Death;
using Features.Fall;
using Features.Fall.presentation;
using Features.Gameplay.Enemies.AttackAreas;
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
        [SerializeField] private CompleteLevelNavigator completeLevelNavigator;
        [SerializeField] private LeverStateNavigator leverStateNavigator;

        public override void InstallBindings()
        {
            Container.Bind<LevelFailedAnalyticsEventUseCase>().AsSingle();
            Container.Bind<IDeathCounterRepository>().To<DeathCounterDefaultRepository>().AsSingle();
            Container.Bind<DeathNavigator>().AsSingle();
            Container.Bind<AttackAreaNavigator>().AsSingle();
            Container.BindInstance(completeLevelNavigator).AsSingle();
            Container.BindInstance(leverStateNavigator).AsSingle();
        }
    }
}