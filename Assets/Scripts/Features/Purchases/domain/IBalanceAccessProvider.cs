using System;
using Features.Purchases.domain.model;

namespace Features.Purchases.domain
{
    public interface IBalanceAccessProvider
    {
        IObservable<bool> CanRemove(int value, PurchaseType type);
        IObservable<bool> Remove(int value, PurchaseType type);
    }
}