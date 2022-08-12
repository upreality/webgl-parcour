using System;
using Features.Purchases.domain;
using Features.Purchases.domain.model;
using Features.Purchases.domain.repositories;
using UniRx;
using UnityEngine;
using Zenject;

namespace Features.Purchases.presentation.ui
{
    public class DefaultPurchaseItemController : MonoBehaviour, PurchaseItem.IPurchaseItemController
    {
        [Inject] private IPurchaseAnalyticsRepository analytics;
        [Inject] private PurchasedStateUseCase purchasedStateUseCase;
        [Inject] private CurrencyPurchaseUseCase currencyPurchaseUseCase;
        [Inject] private PurchaseAvailableUseCase purchaseAvailableUseCase;
        [Inject] private RewardedVideoPurchaseUseCase rewardedVideoPurchaseUseCase;
        [Inject] private IPurchaseRepository purchaseRepository;

        [Inject] private IPurchaseItemSelectionAdapter selectionAdapter;

        public void OnItemClick(long purchaseId) => purchasedStateUseCase
            .GetPurchasedState(purchaseId)
            .Subscribe(purchasedState =>
                HandleItemClick(purchasedState, purchaseId)
            ).AddTo(this);

        public IObservable<bool> GetPurchasedState(long purchaseId) => purchasedStateUseCase
            .GetPurchasedState(purchaseId);

        private void TryRewardedVideoPurchase(long purchaseId) => rewardedVideoPurchaseUseCase
            .LaunchRewardedVideo(purchaseId)
            .Subscribe() //Ignore result
            .AddTo(this);

        private void TryCoinsPurchase(long purchaseId) => purchaseAvailableUseCase
            .GetPurchaseAvailable(purchaseId)
            .Take(1)
            .Where(available => available)
            .SelectMany(currencyPurchaseUseCase.ExecutePurchase(purchaseId))
            .Subscribe((res) => {
                if (res == CurrencyPurchaseUseCase.CurrencyPurchaseResult.Success) analytics.SendPurchasedEvent(purchaseId);
            }) //Ignore result
            .AddTo(this);

        private void HandleItemClick(bool purchasedState, long purchaseId)
        {
            if (purchasedState)
            {
                //Handle Item Selection
                selectionAdapter.SelectItem(purchaseId);
                return;
            }

            switch (purchaseRepository.GetById(purchaseId).Type)
            {
                case PurchaseType.Coins:
                    TryCoinsPurchase(purchaseId);
                    break;
                case PurchaseType.RewardedVideo:
                    TryRewardedVideoPurchase(purchaseId);
                    break;
                case PurchaseType.PassLevelReward:
                    //empty
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public interface IPurchaseItemSelectionAdapter
        {
            public void SelectItem(long purchaseId);
        }
    }
}