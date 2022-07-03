using System;
using Balance.domain.repositories;
using UniRx;
using Zenject;

namespace Balance.domain
{
    public class DecreaseBalanceUseCase
    {
        [Inject] private IBalanceRepository repository;

        public IObservable<bool> GetCanDecrease(int amount, CurrencyType currencyType)
        {
            if (currencyType == CurrencyType.None)
                return Observable.Return(false);
                
            return repository
                .GetBalance(currencyType)
                .Select(balance => balance >= amount);
        }

        // bool
        public IObservable<DecreaseBalanceResult> Decrease(
            int amount,
            CurrencyType currencyType
        ) => GetCanDecrease(amount, currencyType)
            .Take(1)
            .Select(canDecrease =>
                DecreaseBalance(canDecrease, amount, currencyType)
            );

        private DecreaseBalanceResult DecreaseBalance(bool canDecrease, int amount, CurrencyType currencyType)
        {
            if (!canDecrease)
                return DecreaseBalanceResult.LowBalance;

            repository.Remove(amount, currencyType);
            return DecreaseBalanceResult.Success;
        }

        public enum DecreaseBalanceResult
        {
            Success,
            LowBalance,
            UnexpectedFailure
        }
    }
}