using System.Collections.Generic;
using UnityEngine;

namespace Data.BuildingsData
{
    [CreateAssetMenu(menuName = "BuildingEntity")]
    public class BuildingEntity : ScriptableObject
    {
        [Header("Description")]
        public Sprite image;
        [Header("Russian")] public string ruName;
        [TextArea(1, 5)] public string ruDesc;
        [Header("English")] public string enName;
        [TextArea(1, 5)] public string enDesc;

        [Header("Progression")]
        public int defaultLevel = 0;
        public List<SkillEntity> skillLevels = new();
    }
}