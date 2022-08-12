using System.Collections.Generic;
using UnityEngine;

namespace Features.Buildings.data
{
    public class BuildingEntityDao: ScriptableObject
    {
        [SerializeField] private List<BuildingEntity> entities = new();
    }
}