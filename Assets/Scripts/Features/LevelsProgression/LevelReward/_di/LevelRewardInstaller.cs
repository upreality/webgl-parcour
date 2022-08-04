using Features.LevelsProgression.LevelReward.data;
using Features.LevelsProgression.LevelsScore.data;
using UnityEngine;
using Zenject;

namespace Features.LevelsProgression.LevelReward._di
{
    [CreateAssetMenu(menuName = "Installers/LevelRewardInstaller")]
    public class LevelRewardInstaller: ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<LevelRewardRepository>().AsSingle();
        }
    }
}