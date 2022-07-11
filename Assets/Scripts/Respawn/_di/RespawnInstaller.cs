using Levels.presentation.respawn;
using Respawn.presentation;
using UnityEngine;
using Zenject;

namespace Respawn._di
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