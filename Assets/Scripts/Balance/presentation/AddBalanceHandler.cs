using Balance.domain;
using Balance.domain.repositories;
using UnityEngine;
using Zenject;

namespace Balance.presentation
{
    public class AddBalanceHandler : MonoBehaviour
    {
        [SerializeField] private int amount;
        [SerializeField] private CurrencyType currencyType = CurrencyType.Primary;
        [Inject] private IBalanceRepository balanceRepository;

        public void AddBalance()
        {
            if (balanceRepository != null) balanceRepository.Add(amount, currencyType);
        }
    }
}
