using System;

namespace Features.Balance.domain.repositories
{
    public interface IBalanceRepository
    {
        IObservable<int> GetBalance(CurrencyType currencyType);
        void Add(int value, CurrencyType currencyType);
        void Remove(int value, CurrencyType currencyType);
    }
}