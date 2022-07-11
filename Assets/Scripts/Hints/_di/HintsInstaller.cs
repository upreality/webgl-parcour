﻿using Hints.data;
using Hints.domain;
using Hints.presentation;
using UnityEngine;
using Zenject;

namespace Hints._di
{
    [CreateAssetMenu(menuName = "Installers/HintsInstaller")]
    public class HintsInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            //Repositories
            Container.Bind<ICurrentHintRepository>().To<CurrentHintInMemoryRepository>().AsSingle();

            var navigator = FindObjectOfType<HintsNavigator>();
            Container.BindInstance(navigator).AsSingle();
        }
    }
}