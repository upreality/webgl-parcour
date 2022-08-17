using System.Collections.Generic;
using UnityEngine;

namespace Data.BuildingsData
{
    [CreateAssetMenu(menuName = "Buildings/BuildingsDao/DefaultBuildingsDao")]
    internal class DefaultBuildingsDao : ScriptableObject, IBuildingsDao
    {
        [SerializeField] private SerializableDictionary<BuildingType, BuildingEntity> entities = new();

        public IDictionary<BuildingType, BuildingEntity> GetBuildings() => entities;

        public BuildingEntity GetBuilding(BuildingType type) => entities[type];
    }
}