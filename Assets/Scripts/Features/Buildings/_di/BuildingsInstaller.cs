using Data.PurchasesData;
using Features.Buildings.data;
using Features.Buildings.domain;
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

            Container
                .Bind<IPurchaseEntitiesDao>()
                .To<PurchaseEntitiesDaoBuildingLevelPurchasesDecorator>()
                .AsSingle();

            Container.BindInterfacesAndSelfTo<BuildingProgressStateUseCase>().AsSingle();
            Container.BindInterfacesAndSelfTo<UpgradeBuildingUseCase>().AsSingle();
        }
    }
}