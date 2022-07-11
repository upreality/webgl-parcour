using SDK.Platform.domain;
using UnityEngine;
using Zenject;

namespace PlayerInput.FirstPersonLook
{
    public class FirstPersonLookDeltaProviderRouter: global::FirstPersonLook.ILookDeltaProvider
    {
        [Inject(Id = "DesktopLookDeltaProvider")] private global::FirstPersonLook.ILookDeltaProvider desktopProvider;
        [Inject(Id = "MobileLookDeltaProvider")] private global::FirstPersonLook.ILookDeltaProvider mobileProvider; 
        [Inject] private IPlatformProvider platformProvider;

        private bool initialized = false;
        private bool isOnDesktop = true;
        
        public Vector2 GetDelta()
        {
            if (!initialized)
            {
                isOnDesktop = platformProvider.GetCurrentPlatform() == Platform.Desktop;
                initialized = true;
            }
            return isOnDesktop? desktopProvider.GetDelta() : mobileProvider.GetDelta();
        }
    }
}