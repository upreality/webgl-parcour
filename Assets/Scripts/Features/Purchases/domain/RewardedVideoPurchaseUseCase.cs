﻿using System;
using Features.Purchases.domain.repositories;
using UniRx;
using Zenject;

namespace Features.Purchases.domain
{
    public class RewardedVideoPurchaseUseCase
    {
        [Inject] private IRewardedVideoPurchasePresenterAdapter adapter;
        [Inject] private IRewardedVideoPurchaseRepository rewardedVideoPurchaseRepository;
        [Inject] private PurchasedStateUseCase purchasedStateUseCase;

        public IObservable<ShowRewardedVideoResult> LaunchRewardedVideo(string purchaseId) => adapter
            ?.ShowRewarded()
            .SelectMany(result =>
                GetPurchaseShowVideoResult(result, purchaseId)
            );

        private IObservable<ShowRewardedVideoResult> GetPurchaseShowVideoResult(bool videoShown, string purchaseId)
        {
            if (!videoShown)
                return Observable.Return(ShowRewardedVideoResult.Failure);

            rewardedVideoPurchaseRepository.AddRewardedVideoWatch(purchaseId);
            return purchasedStateUseCase
                .GetPurchasedState(purchaseId)
                .Select(purchased =>
                    purchased ? ShowRewardedVideoResult.Purchased : ShowRewardedVideoResult.InProgress
                );
        }

        public interface IRewardedVideoPurchasePresenterAdapter
        {
            public IObservable<bool> ShowRewarded();
        }

        public enum ShowRewardedVideoResult
        {
            Purchased,
            InProgress,
            Failure
        }
    }
}