using System;
using Features.Balance.domain;
using Features.Balance.domain.repositories;
using UniRx;

namespace Features.Balance.data
{
    public class InfiniteThousandBalanceRepository: IBalanceRepository
    {
        public IObservable<int> GetBalance(CurrencyType currencyType)
        {
            return Observable.Return(1000);
        }

        public void Add(int value, CurrencyType currencyType)
        {
            //do nothing
        }

        public void Remove(int value, CurrencyType currencyType)
        {
            //do nothing
        }
    }
}