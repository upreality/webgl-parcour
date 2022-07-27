using System;
using Core.RewardedVideo.domain;
using Core.RewardedVideo.domain.model;
using Features.Purchases.domain;
using UniRx;
using Zenject;

namespace Features.Purchases.adapters
{
    public class RewardedVideoPresenterAdapter : RewardedVideoPurchaseUseCase.IRewardedVideoPurchasePresenterAdapter
    {
        [Inject] private IRewardedVideoNavigator rewardedVideoNavigator;

        public IObservable<bool> ShowRewarded() => rewardedVideoNavigator
            .ShowRewardedVideo()
            .Select(result => result == ShowRewardedVideoResult.Success);
    }
}