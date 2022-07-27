using System;

namespace Features.Purchases.domain.repositories
{
    public interface IRewardedVideoPurchaseRepository
    {
        void AddRewardedVideoWatch(long id);
        IObservable<int> GetRewardedVideoCurrentWatchesCount(long id);
        int GetRewardedVideoWatchesCount(long id);
    }
}