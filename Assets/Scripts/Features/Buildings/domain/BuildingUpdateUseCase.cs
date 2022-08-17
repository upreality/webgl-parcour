using Features.Balance.domain.repositories;
using Features.Purchases.domain.repositories;
using Zenject;
using static Features.Buildings.domain.BuildingProgressStateUseCase.BuildingProgress;

namespace Features.Buildings.domain
{
    public class BuildingUpdateUseCase
    {
        [Inject] private BuildingProgressStateUseCase progressStateUseCase;
        [Inject] private IPurchaseRepository buildingPurchaseRepository;

        [Inject(Id = IBuildingLevelRepository.DefaultInstance)]
        private IBuildingLevelRepository levelRepository;

        [Inject] private IBalanceRepository balanceRepository;
        [Inject] private IBuildingDataRepository dataRepository;

        public UpdateResult UpdateBuilding(int buildingId)
        {
            var progressState = progressStateUseCase.GetState(buildingId);
            return progressState.Progress != CompletelyUpgraded
                ? Build(buildingId, progressState.Level)
                : UpdateResult.MaxLevelReached;
        }

        private UpdateResult Build(int buildingId, int levelId)
        {
            
        }

        public enum UpdateResult
        {
            Error,
            NotEnoughMoney,
            MaxLevelReached,
            Success
        }
    }
}