using System.Collections.Generic;

namespace Data.BuildingsData
{
    public interface IBuildingsDao
    {
        public IDictionary<BuildingType, BuildingEntity> GetBuildings();
        BuildingEntity GetBuilding(BuildingType type);
    }
}