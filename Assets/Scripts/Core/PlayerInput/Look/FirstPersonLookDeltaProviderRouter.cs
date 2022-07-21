using Core.SDK.Platform.domain;
using FPSController;
using UnityEngine;
using Zenject;

namespace Core.PlayerInput.Look
{
    public class FirstPersonLookDeltaProviderRouter: FirstPersonLook.ILookDeltaProvider
    {
        [Inject(Id = "DesktopLookDeltaProvider")] private FirstPersonLook.ILookDeltaProvider desktopProvider;
        [Inject(Id = "MobileLookDeltaProvider")] private FirstPersonLook.ILookDeltaProvider mobileProvider; 
        [Inject] private IPlatformProvider platformProvider;

        private bool initialized = false;
        private bool isOnDesktop = true;
        
        public Vector2 GetDelta()
        {
            if (initialized) 
                return isOnDesktop ? desktopProvider.GetDelta() : mobileProvider.GetDelta();
            
            isOnDesktop = platformProvider.GetCurrentPlatform() == Platform.Desktop;
            initialized = true;
            return isOnDesktop? desktopProvider.GetDelta() : mobileProvider.GetDelta();
        }
    }
}