using System;
using System.Collections.Generic;
using System.Linq;
using ModestTree;
using UnityEngine;

namespace Data.BuildingsData
{
    [CreateAssetMenu(menuName = "Buildings/DefaultBuildingsDao")]
    internal class DefaultBuildingsDao : ScriptableObject, IBuildingsDao
    {
        [SerializeField] private SerializableDictionary<BuildingType, BuildingEntity> entities = new();

        public IDictionary<BuildingType, BuildingEntity> GetBuildings() => entities;

        public BuildingEntity GetBuilding(BuildingType type) => entities[type];
    }
}