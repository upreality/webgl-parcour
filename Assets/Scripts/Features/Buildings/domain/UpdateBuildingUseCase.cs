using System;
using Features.Purchases.domain;
using UniRx;
using Zenject;
using static Features.Buildings.domain.BuildingProgressStateUseCase.BuildingProgress;
using static Features.Purchases.domain.ExecutePurchaseUseCase;

namespace Features.Buildings.domain
{
    public class UpdateBuildingUseCase
    {
        [Inject] private BuildingProgressStateUseCase progressStateUseCase;

        [Inject] private ExecutePurchaseUseCase executePurchaseUseCase;
        [Inject] private IBuildingDataRepository dataRepository;

        public IObservable<UpdateResult> UpdateBuilding(string buildingId)
        {
            var progressState = progressStateUseCase.GetState(buildingId);
            return progressState.Progress != CompletelyUpgraded
                ? Build(buildingId, progressState.Level++)
                : Observable.Return(UpdateResult.MaxLevelReached);
        }

        private IObservable<UpdateResult> Build(string buildingId, int levelId)
        {
            var buildingData = dataRepository.GetBuilding(buildingId);
            var purchase = buildingData.LevelPurchases[levelId];
            return executePurchaseUseCase.ExecutePurchase(purchase.Id).Select(GetUpdateResult);
        }

        private static UpdateResult GetUpdateResult(PurchaseResult purchaseResult) => purchaseResult switch
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