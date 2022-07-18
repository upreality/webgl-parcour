using Features.Balance.domain;
using UnityEngine;
using Zenject;

namespace Features.Balance.presentation
{
    public class AddBalanceHandler : MonoBehaviour
    {
        [SerializeField] private int amount;
        [SerializeField] private CurrencyType currencyType = CurrencyType.Primary;
        [Inject] private AddBalanceNavigator balanceNavigator;

        public void AddBalance()
        {
            if (balanceNavigator != null)
                balanceNavigator.AddBalance(amount, currencyType);
        }
    }
}