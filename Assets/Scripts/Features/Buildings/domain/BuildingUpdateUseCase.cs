using System;
using Features.Balance.domain.repositories;
using Zenject;
using static Features.Buildings.domain.BuildingProgressStateUseCase.BuildingProgress;

namespace Features.Buildings.domain
{
    public class BuildingUpdateUseCase
    {
        [Inject] private BuildingProgressStateUseCase progressStateUseCase;
        [Inject(Id = IBuildingLevelRepository.DefaultInstance)] private IBuildingLevelRepository levelRepository;
        [Inject] private IBalanceRepository balanceRepository;
        [Inject] private IBuildingDataRepository dataRepository;

        public UpdateResult UpdateBuilding(int buildingId)
        {
            var progressState = progressStateUseCase.GetState(buildingId);
            
            return progressState.Progress switch
            {
                NotBuilt => expr,
                UpgradeAvailable => expr,
                CompletelyUpgraded => UpdateResult.MaxLevelReached,
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        private UpdateResult Build()
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