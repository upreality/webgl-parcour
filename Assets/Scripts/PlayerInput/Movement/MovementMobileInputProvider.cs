using UnityEngine;
using Zenject;

namespace PlayerInput.Movement
{
    public class MovementMobileInputProvider : FirstPersonMovement.IMovementInputProvider
    {
        [Inject] private InputHandler handler;

        public Vector2 GetInput()
        {
            var x = handler.GetInput("Horizontal");
            var y = handler.GetInput("Vertical");
            return new Vector2(x, y);
        }

        public bool GetRunningInput() => handler.GetInput("Run") > 0.5f;
    }
}