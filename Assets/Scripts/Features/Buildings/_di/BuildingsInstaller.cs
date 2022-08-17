using System;
using Data.BuildingsData;
using Features.Buildings.data;
using Features.Buildings.domain;
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

            foreach (BuildingType type in Enum.GetValues(typeof(BuildingType)))
            {
                Container
                    .Bind<IPurchaseRepository>()
                    .WithId($"BuildingPurchaseRepository_{type}")
                    .To<BuildingLevelPurchaseRepository>()
                    .WithArguments(type);
            }


            Container.BindInterfacesAndSelfTo<BuildingProgressStateUseCase>().AsSingle();
        }
    }
}