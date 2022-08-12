using Features.Buildings.domain.model;

namespace Features.Buildings.domain
{
    public interface IBuildingRepository
    {
        public Building GetBuilding(BuildingType type);
    }
}