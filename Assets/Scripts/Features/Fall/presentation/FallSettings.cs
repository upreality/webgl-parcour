using UnityEngine;

namespace Features.Fall.presentation
{
    [CreateAssetMenu(menuName = "Settings/FallSettings")]
    public class FallSettings: ScriptableObject
    {
        public float turnUpDuration = 1f;
    }
}