using System.Collections.Generic;
using System.Linq;
using Core.Localization;
using Data.BuildingsData;
using Features.Buildings.domain;
using Features.Buildings.domain.model;
using Features.Purchases.data;
using Features.Purchases.domain.model;
using Zenject;

namespace Features.Buildings.data
{
    public class DefaultBuildingDataRepository : IBuildingDataRepository
    {
        [Inject] private IBuildingsDao buildingsDao;
        [Inject] private ILanguageProvider languageProvider;
        [Inject] private PurchaseEntityConverter purchaseEntityConverter;

        public BuildingData GetBuilding(string buildingId)
        {
            var buildingType = buildingId.IdToBuildingType();
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
                LevelPurchases = GetLevelPurchases(entity)
            };
        }

        private List<Purchase> GetLevelPurchases(BuildingEntity entity) => entity
            .skillLevels
            .Select(level => level.purchase)
            .Select(purchaseEntityConverter.GetPurchaseFromEntity)
            .ToList();
    }
}