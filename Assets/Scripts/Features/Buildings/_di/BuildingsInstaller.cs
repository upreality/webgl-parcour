using System;
using Data.BuildingsData;
using Features.Buildings.data;
using Features.Buildings.domain;
using Features.Purchases.data;
using Features.Purchases.domain;
using Features.Purchases.domain.repositories;
using Zenject;

namespace Features.Buildings._di
{
    public class BuildingsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<DefaultBuildingDataRepository>().AsSingle();

            Container
                .Bind<IBuildingLevelRepository>()
                .To<LocalStorageBuildingLevelRepository>()
                .FromNew()
                .AsSingle()
                .WhenInjectedInto<BuildingLevelRepositoryPlayfabStatDecorator>();

            Container
                .Bind<IBuildingLevelRepository>()
                .WithId(IBuildingLevelRepository.DefaultInstance)
                .To<BuildingLevelRepositoryPlayfabStatDecorator>()
                .AsSingle();
            
            Container.Decorate<IPurchaseRepository>().With<PurchaseRepositoryBuildingLevelPurchasesDecorator>();

            Container.BindInterfacesAndSelfTo<BuildingProgressStateUseCase>().AsSingle();
            Container.BindInterfacesAndSelfTo<UpdateBuildingUseCase>().AsSingle();
        }
    }
}