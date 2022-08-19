using System;
using Features.Purchases.domain;
using UniRx;
using Zenject;
using static Features.Buildings.domain.BuildingProgressStateUseCase.BuildingProgress;
using static Features.Purchases.domain.ExecutePurchaseUseCase;

namespace Features.Buildings.domain
{
    public class UpgradeBuildingUseCase
    {
        [Inject] private BuildingProgressStateUseCase progressStateUseCase;

        [Inject] private ExecutePurchaseUseCase executePurchaseUseCase;
        [Inject] private IBuildingDataRepository dataRepository;
        [Inject(Id = IBuildingLevelRepository.DefaultInstance)] private IBuildingLevelRepository buildingLevelRepository;

        public IObservable<UpdateResult> UpgradeBuilding(string buildingId)
        {
            var progressState = progressStateUseCase.GetState(buildingId);
            return progressState.Progress != CompletelyUpgraded
                ? Build(buildingId, progressState.Level)
                : Observable.Return(UpdateResult.MaxLevelReached);
        }

        private IObservable<UpdateResult> Build(string buildingId, int levelId)
        {
            var buildingData = dataRepository.GetBuilding(buildingId);
            var purchase = buildingData.LevelPurchases[levelId];
            return executePurchaseUseCase
                .ExecutePurchase(purchase.Id)
                .Select(GetUpdateResult)
                .Do(result =>
                {
                    if (result != UpdateResult.Success)
                        return;

                    var currentLevel = buildingLevelRepository.GetLevel(buildingId);
                    if(currentLevel>levelId)
                        return;
                    
                    buildingLevelRepository.SetLevel(buildingId, levelId+1);
                });
        }

        private static UpdateResult GetUpdateResult(PurchaseResult result) => result switch
        {
            PurchaseResult.Success => UpdateResult.Success,
            PurchaseResult.Unavailable => UpdateResult.Unavailable,
            _ => UpdateResult.Error,
        };

        public enum UpdateResult
        {
            Error,
            Unavailable,
            MaxLevelReached,
            Success
        }
    }
}