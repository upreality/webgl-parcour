using System;
using Features.Balance.domain;
using Features.Purchases.domain;
using Features.Purchases.domain.model;
using UniRx;
using Zenject;
using static Features.Balance.domain.DecreaseBalanceUseCase;

namespace Features.Purchases.adapters
{
    public class BalanceAccessProviderAdapter : IBalanceAccessProvider
    {
        [Inject] private DecreaseBalanceUseCase decreaseBalanceUseCase;

        public IObservable<bool> CanRemove(int value, PurchaseType type)
        {
            var currencyType = GetCurrencyType(type);
            return decreaseBalanceUseCase.GetCanDecreaseFlow(value, currencyType);
        }

        public IObservable<bool> Remove(int value, PurchaseType type)
        {
            var currencyType = GetCurrencyType(type);
            return decreaseBalanceUseCase
                .Decrease(value, currencyType)
                .Select(result => result == DecreaseBalanceResult.Success);
        }

        private static CurrencyType GetCurrencyType(PurchaseType type) => type switch
        {
            PurchaseType.Coins => CurrencyType.Primary,
            PurchaseType.Prisoners => CurrencyType.Secondary,
            _ => CurrencyType.None
        };
    }
}