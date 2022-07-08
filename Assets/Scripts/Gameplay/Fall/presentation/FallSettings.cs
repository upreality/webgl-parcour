using UnityEngine;

namespace Gameplay.Fall.presentation
{
    [CreateAssetMenu(menuName = "Settings/FallSettings")]
    public class FallSettings: ScriptableObject
    {
        public float turnUpDuration = 1f;
    }
}