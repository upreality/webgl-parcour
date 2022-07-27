using System;

namespace Features.Purchases.domain
{
    public interface ILevelPassedStateProvider
    {
        IObservable<bool> GetLevelPassedState(long levelId);
    }
}