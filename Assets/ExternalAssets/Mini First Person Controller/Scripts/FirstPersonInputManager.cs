using Core.SDK.GameState;
using UniRx;
using UnityEngine;
using Zenject;

namespace FPSController
{
    public class FirstPersonInputManager : MonoBehaviour
    {
        [Inject] private GameStateNavigator gameStateNavigator;
        [Inject] private FirstPersonLook look;
        [Inject] private FirstPersonMovement movement;

        private void Start() => gameStateNavigator
            .GetGameState()
            .Select(state => state == GameState.Active)
            .Subscribe(SetControlsEnabled)
            .AddTo(this);

        private void SetControlsEnabled(bool state)
        {
            if (!state)
                movement.ResetVelocity();

            look.SetEnabledState(state);
            movement.enabled = state;
        }
    }
}