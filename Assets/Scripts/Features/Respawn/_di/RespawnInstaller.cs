using Features.Respawn.presentation;
using Features.Respawn.presentation.Fade;
using Features.Respawn.presentation.Spawns;
using UnityEngine;
using Zenject;

namespace Features.Respawn._di
{
    public class RespawnInstaller : MonoInstaller
    {
        [SerializeField] private RespawnNavigator respawnNavigator;
        [SerializeField] private SpawnNavigator spawnNavigator;
        [SerializeField] private SpawnFadeNavigator spawnFadeNavigator;

        public override void InstallBindings()
        {
            Container.Bind<SpawnNavigator>().FromInstance(spawnNavigator).AsSingle();
            Container.BindInterfacesAndSelfTo<RespawnNavigator>().FromInstance(respawnNavigator).AsSingle();
            Container.Bind<SpawnFadeNavigator>().FromInstance(spawnFadeNavigator).AsSingle();
        }
    }
}