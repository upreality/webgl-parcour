using System;
using UnityEngine;

namespace Features.BuildingsUpgrade.Data
{
    [Serializable]
    public class SkillData
    {
        [field:SerializeField] public string Name { get; private set; }
        [field:SerializeField] public string Description { get; private set; }
    }
}