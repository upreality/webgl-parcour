using UnityEngine;
using FPSController;
using static UnityEngine.Input;

namespace Core.PlayerInput.Look
{
    public class FirstPersonLookDesktopDeltaProvider: FirstPersonLook.ILookDeltaProvider
    {
        public Vector2 GetDelta() => new(GetAxisRaw("Mouse X"), GetAxisRaw("Mouse Y"));
    }
}