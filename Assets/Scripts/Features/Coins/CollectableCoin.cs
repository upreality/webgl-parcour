using Features.Balance.domain;
using Features.Balance.presentation;
using UnityEngine;
using Utils.PlayerTrigger;
using Zenject;

namespace Features.Coins
{
    public class CollectableCoin : PlayerTriggerBase
    {
        [Inject] private AddBalanceNavigator addBalanceNavigator;
        [SerializeField] private ParticleSystem collectParticles;
        [SerializeField] private Animator animator;
        [SerializeField] private CurrencyType currencyType = CurrencyType.Primary;
        [SerializeField] private string trigger = "collect";

        protected override void OnPlayerEntersTrigger()
        {
            animator.SetTrigger(trigger);
            collectParticles.Play();
            addBalanceNavigator.AddBalance(1, currencyType);
        }

        protected override void OnPlayerExitTrigger()
        {
            //Do nothing
        }
    }
}
