using Features.LevelScore.data;
using Features.LevelScore.domain;
using UnityEngine;
using Zenject;

namespace Features.LevelScore._di
{
    [CreateAssetMenu(menuName = "Installers/LevelScoreInstaller")]
    public class LevelScoreInstaller: ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<LevelScoreLocalDataSource>().AsSingle();
            Container.BindInterfacesAndSelfTo<LevelScoreRepository>().AsSingle();
            Container.BindInterfacesAndSelfTo<CurrentLevelScoreUseCase>().AsSingle();
        }
    }
}