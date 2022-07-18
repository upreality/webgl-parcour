using ExternalAssets.Mini_First_Person_Controller.Scripts;
using UnityEngine;
using static UnityEngine.Input;

namespace Core.PlayerInput.Movement
{
    public class MovementDesktopInputProvider : FirstPersonMovement.IMovementInputProvider
    {
        public Vector2 GetInput() => new(GetAxis("Horizontal"), GetAxis("Vertical"));
        public bool GetRunningInput() => GetKey(KeyCode.LeftShift);
    }
}