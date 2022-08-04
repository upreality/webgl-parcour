using Features.LevelsProgression.LevelsScore.data;
using UnityEngine;
using Zenject;

namespace Features.LevelsProgression.LevelsScore._di
{
    [CreateAssetMenu(menuName = "Installers/LevelScoreInstaller")]
    public class LevelScoreInstaller: ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<LevelScoreLocalDataSource>().AsSingle();
            Container.BindInterfacesAndSelfTo<LevelScoreRepository>().AsSingle();
        }
    }
}