using Features.Levels.presentation.respawn;
using Features.Respawn.presentation;
using UnityEngine;
using Zenject;

namespace Features.Respawn._di
{
    public class RespawnInstaller: MonoInstaller
    {
        [SerializeField] private RespawnNavigator respawnNavigator;
        public override void InstallBindings()
        {
            Container.Bind<IRespawnNavigator>().FromInstance(respawnNavigator).AsSingle();
        }
    }
}