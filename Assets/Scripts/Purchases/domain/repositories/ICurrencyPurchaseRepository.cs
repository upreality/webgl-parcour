using System;
using Purchases.domain.model;

namespace Purchases.domain.repositories
{
    public interface ICurrencyPurchaseRepository
    {
        int GetCost(long purchaseId);
        void SetPurchased(long purchaseId);
        IObservable<bool> GetPurchasedState(long purchaseId);
    }
}