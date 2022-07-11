using Balance.presentation;
using Gameplay.PlayerTriggers;
using UnityEngine;
using Zenject;

namespace Coins
{
    public class CollectableCoin : PlayerTriggerBase
    {
        [Inject] private AddBalanceNavigator addBalanceNavigator;
        [SerializeField] private ParticleSystem collectParticles;
        [SerializeField] private Animator animator;
        [SerializeField] private string trigger = "collect";

        protected override void OnPlayerEntersTrigger()
        {
            animator.SetTrigger(trigger);
            collectParticles.Play();
            addBalanceNavigator.AddBalance(1);
        }

        protected override void OnPlayerExitTrigger()
        {
            //Do nothing
        }
    }
}
