using UnityEngine;

namespace Features.Fall
{
    [CreateAssetMenu(menuName = "Settings/FallSettings")]
    public class FallSettings: ScriptableObject
    {
        public float turnUpDuration = 1f;
    }
}