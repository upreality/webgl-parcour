using Features.Buildings.domain.model;

namespace Features.Buildings.domain
{
    public interface IBuildingDataRepository
    {
        public BuildingData GetBuilding(string buildingId);
    }
}