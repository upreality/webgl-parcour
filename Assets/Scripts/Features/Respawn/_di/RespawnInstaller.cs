using Features.Respawn.presentation;
using UnityEngine;
using Zenject;

namespace Features.Respawn._di
{
    public class RespawnInstaller : MonoInstaller
    {
        [SerializeField] private RespawnNavigator respawnNavigator;
        [SerializeField] private SpawnNavigator spawnNavigator;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<RespawnNavigator>().FromInstance(respawnNavigator).AsSingle();
            Container.Bind<SpawnNavigator>().FromInstance(spawnNavigator).AsSingle();
        }
    }
}