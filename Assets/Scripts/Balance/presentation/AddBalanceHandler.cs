using UnityEngine;
using Zenject;

namespace Balance.presentation
{
    public class AddBalanceHandler : MonoBehaviour
    {
        [SerializeField] private int amount;
        [Inject] private AddBalanceNavigator balanceNavigator;

        public void AddBalance()
        {
            if (balanceNavigator != null)
                balanceNavigator.AddBalance(amount);
        }
    }
}