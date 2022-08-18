using System;
using Features.Purchases.domain.model;
using Features.Purchases.domain.repositories;
using UniRx;
using Zenject;

namespace Features.Purchases.domain
{
    public class PurchaseAvailableUseCase
    {
        [Inject] private PurchasedStateUseCase purchasedStateUseCase;
        [Inject] private IPurchaseRepository repository;
        [Inject] private IBalanceAccessProvider balance;
        [Inject] private ICurrencyPurchaseRepository currencyPurchaseRepository;
        [Inject] private IRewardedVideoPurchaseRepository videoPurchaseRepository;

        public IObservable<bool> GetPurchaseAvailable(string purchaseId) => purchasedStateUseCase
            .GetPurchasedState(purchaseId)
            .SelectMany(state =>
                state ? Observable.Return(false) : GetPurchaseAvailableState(purchaseId)
            );

        private IObservable<bool> GetPurchaseAvailableState(string purchaseId)
        {
            var purchase = repository.GetById(purchaseId);
            switch (purchase.Type)
            {
                case PurchaseType.Coins:
                    var coins = currencyPurchaseRepository.GetCost(purchaseId);
                    return balance.CanRemove(coins, PurchaseType.Coins);
                case PurchaseType.Prisoners:
                    var prisoners = currencyPurchaseRepository.GetCost(purchaseId);
                    return balance.CanRemove(prisoners, PurchaseType.Coins);
                case PurchaseType.RewardedVideo:
                    var currentWatchesFlow = videoPurchaseRepository.GetRewardedVideoCurrentWatchesCount(purchaseId);
                    var requiredWatches = videoPurchaseRepository.GetRewardedVideoWatchesCount(purchaseId);
                    return currentWatchesFlow.Select(currentWatches => currentWatches + 1 >= requiredWatches);
                case PurchaseType.PassLevelReward:
                    return Observable.Return(false);
                default:
                    return Observable.Return(false);
            }
        }
    }
}