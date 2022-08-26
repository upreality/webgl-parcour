using Features.BuildingsUpgrade.Data;
using Features.BuildingsUpgrade.Interactions;
using Features.BuildingsUpgrade.Settings;
using UnityEngine;
using Zenject;

namespace Features.BuildingsUpgrade.Installer
{
    public class UpgradeInstaller : MonoInstaller
    {
        [SerializeField] private UpgradeSettings upgradeSettings;
        [SerializeField] private UpgradeRepository upgradeRepository;
        
        public override void InstallBindings()
        {
            Container
                .BindInstance(upgradeRepository)
                .AsSingle();
            
            Container
                .BindInterfacesTo<UpgradeSettings>()
                .FromInstance(upgradeSettings)
                .AsSingle();

            Container
                .BindInterfacesTo<BuildingPresenter>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesTo<BuildingView>()
                .AsSingle();
            
            Container
                .BindInterfacesTo<BuildingModel>()
                .AsSingle();
        }
    }
}