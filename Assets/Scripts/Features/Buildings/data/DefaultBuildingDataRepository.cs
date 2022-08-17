using Core.Localization;
using Data.BuildingsData;
using Features.Buildings.domain;
using Features.Buildings.domain.model;
using Zenject;

namespace Features.Buildings.data
{
    public class DefaultBuildingDataRepository: IBuildingDataRepository
    {
        [Inject] private IBuildingsDao buildingsDao;
        [Inject] private ILanguageProvider languageProvider;
        public BuildingData GetBuilding(int buildingId)
        {
            var buildingType = buildingId.BuildingTypeFromId();
            var entity = buildingsDao.GetBuilding(buildingType);
            return ToBuildingData(entity);
        }

        private BuildingData ToBuildingData(BuildingEntity entity)
        {
            var isRu = languageProvider.GetCurrentLanguage() == Language.Russian;
            return new BuildingData
            {
                Description = isRu ? entity.ruDesc : entity.enDesc,
                Name = isRu ? entity.ruName : entity.enName,
                Image = entity.image,
                MaxLevel = entity.levelsCount
            };
        }
    }
}