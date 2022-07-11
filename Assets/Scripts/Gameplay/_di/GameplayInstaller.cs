﻿using Gameplay.Death;
using Gameplay.Fall.presentation;
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

        public override void InstallBindings()
        {
            Container.Bind<LevelFailedAnalyticsEventUseCase>().AsSingle();
            Container.Bind<DeathNavigator>().AsSingle();
            Container.BindInstance(fallSettings).AsSingle();
            Container.BindInstance(respawnNavigator).AsSingle();
            Container.Bind<IFallNavigator>().FromInstance(fallNavigator).AsSingle();
            Container.BindInstance(completeLevelNavigator).AsSingle();
        }
    }
}