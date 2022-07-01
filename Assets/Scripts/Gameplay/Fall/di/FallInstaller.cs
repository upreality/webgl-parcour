using System;
using Gameplay.Fall.presenatation;
using UnityEngine;
using Zenject;

namespace Gameplay.Fall.di
{
    public class FallInstaller: MonoInstaller
    {
        [SerializeField] private FallSettings fallSettings;
        [SerializeField] private FallNavigator fallNavigator;
        public override void InstallBindings()
        {
            Container.BindInstance(fallSettings).AsSingle();
            Container.Bind<IFallNavigator>().FromInstance(fallNavigator).AsSingle();
        }
    }
}