using ExternalAssets.Mini_First_Person_Controller.Scripts;
using SDK.Platform.domain;
using UnityEngine;
using Zenject;

namespace PlayerInput.Movement
{
    public class MovementInputProviderRouter : FirstPersonMovement.IMovementInputProvider
    {
        [Inject(Id = "DesktopMovementProvider")] private FirstPersonMovement.IMovementInputProvider desktopProvider;
        [Inject(Id = "MobileMovementProvider")] private FirstPersonMovement.IMovementInputProvider mobileProvider;
        [Inject] private IPlatformProvider platformProvider;

        private bool initialized = false;
        
        private bool isOnDesktop = true;

        public Vector2 GetInput() => GetCurrentProvider().GetInput();
        public bool GetRunningInput() => GetCurrentProvider().GetRunningInput();

        private void CheckInit()
        {
            if (initialized) return;
            isOnDesktop = platformProvider.GetCurrentPlatform() == Platform.Desktop;
            initialized = true;
        }

        private FirstPersonMovement.IMovementInputProvider GetCurrentProvider()
        {
            CheckInit();
            return isOnDesktop ? desktopProvider : mobileProvider;
        }
    }
}