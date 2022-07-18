using UnityEngine;
using static UnityEngine.Input;

namespace Core.PlayerInput.FirstPersonLook
{
    public class FirstPersonLookDesktopDeltaProvider: global::FirstPersonLook.ILookDeltaProvider
    {
        public Vector2 GetDelta() => new(GetAxisRaw("Mouse X"), GetAxisRaw("Mouse Y"));
    }
}