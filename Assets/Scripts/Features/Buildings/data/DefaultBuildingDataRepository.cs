using Core.Localization;
using Data.BuildingsData;
using Features.Buildings.domain;
using Features.Buildings.domain.model;
using Zenject;

namespace Features.Buildings.data
{
    public class DefaultBuildingDataRepository : IBuildingDataRepository
    {
        [Inject] private IBuildingsDao buildingsDao;
        [Inject] private ILanguageProvider languageProvider;

        public BuildingData GetBuilding(string buildingId)
        {
            var buildingType = buildingId.ToBuildingType();
            var entity = buildingsDao.GetBuilding(buildingType);
            return ToBuildingData(entity, buildingId);
        }

        private BuildingData ToBuildingData(BuildingEntity entity, string buildingId)
        {
            var isRu = languageProvider.GetCurrentLanguage() == Language.Russian;
            return new BuildingData
            {
                Id = buildingId,
                Description = isRu ? entity.ruDesc : entity.enDesc,
                Name = isRu ? entity.ruName : entity.enName,
                Image = entity.image,
                MaxLevel = entity.skillLevels.Count
            };
        }
    }
}