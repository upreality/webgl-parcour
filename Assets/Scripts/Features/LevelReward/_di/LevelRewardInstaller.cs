using Features.LevelReward.data;
using UnityEngine;
using Zenject;

namespace Features.LevelReward._di
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