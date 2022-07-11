using System;
using Purchases.domain.model;
using Purchases.domain.repositories;
using UniRx;
using Zenject;

namespace Purchases.domain
{
    public class PurchaseAvailableUseCase
    {
        [Inject] private PurchasedStateUseCase purchasedStateUseCase;
        [Inject] private IPurchaseRepository repository;
        [Inject] private IBalanceAccessProvider balance;
        [Inject] private ICurrencyPurchaseRepository currencyPurchaseRepository;
        [Inject] private IRewardedVideoPurchaseRepository videoPurchaseRepository;

        public IObservable<bool> GetPurchaseAvailable(long purchaseId) => purchasedStateUseCase
            .GetPurchasedState(purchaseId)
            .SelectMany(state =>
                state ? Observable.Return(false) : GetPurchaseAvailableState(purchaseId)
            );

        private IObservable<bool> GetPurchaseAvailableState(long purchaseId)
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