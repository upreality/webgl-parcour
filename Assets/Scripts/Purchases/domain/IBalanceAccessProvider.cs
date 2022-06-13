using System;
using Purchases.domain.model;

namespace Purchases.domain
{
    public interface IBalanceAccessProvider
    {
        IObservable<bool> CanRemove(int value, PurchaseType type);
        IObservable<bool> Remove(int value, PurchaseType type);
    }
}