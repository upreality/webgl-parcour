using Features.Levels.presentation.respawn;
using UnityEngine;
using Utils.PlayerTrigger;
using Zenject;

namespace Features.Keys.presentation
{
    public class CollectableKey : PlayerTriggerBase
    {
        [SerializeField] private ParticleSystem collectParticles;
        [SerializeField] private Animator animator;
        [SerializeField] private BoxCollider triggerCollider;
        [SerializeField] private string trigger = "collect";

        [Inject] private KeyCollectNavigator keyCollectNavigator;
        [Inject] private IRespawnNavigator respawnNavigator;

        private void Awake() => respawnNavigator.OnRespawn += Rebind;

        protected override void OnPlayerEntersTrigger()
        {
            triggerCollider.enabled = false;
            keyCollectNavigator.Collect();
            animator.SetTrigger(trigger);
            collectParticles.Play();
        }

        protected override void OnPlayerExitTrigger()
        {
            //Do nothing
        }

        private void Rebind()
        {
            animator.Rebind();
            triggerCollider.enabled = true;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            respawnNavigator.OnRespawn -= Rebind;
        }
    }
}