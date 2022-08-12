using Features.Buildings.domain;
using UnityEngine;

namespace Features.Buildings.data
{
    [CreateAssetMenu(menuName = "BuildingEntity")]
    public class BuildingEntity : ScriptableObject
    {
        [Header("Russian")] public string ruName;
        [TextArea(1, 5)] public string ruDesc;
        [Header("English")] public string enName;
        [TextArea(1, 5)] public string enDesc;

        public BuildingType type;
        public int buildCost = 100;
    }
}