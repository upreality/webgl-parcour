using Features.LevelTime.data;
using UnityEngine;
using Zenject;

namespace Features.LevelTime._di
{
    public class LevelTimeInstaller: MonoInstaller
    {
        [SerializeField] private LevelTimerSceneRepository levelTimerSceneRepository;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<LevelTimerSceneRepository>().FromInstance(levelTimerSceneRepository).AsSingle();
        }
    }
}