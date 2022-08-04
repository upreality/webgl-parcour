using UnityEngine;
using Utils.PlayerTrigger;
using Zenject;

namespace Features.Respawn.presentation.Fade
{
    public class SpawnFadeArea : PlayerTriggerBase
    {
        [SerializeField] private float duration = 0.25f;
        [Inject] private SpawnFadeNavigator fadeNavigator;
        protected override void OnPlayerEntersTrigger()
        {
            fadeNavigator.SetFadeState(true, duration);
        }

        protected override void OnPlayerExitTrigger() => fadeNavigator.SetFadeState(false, duration);
    }
}