using System.Collections.Generic;
using System.Linq;
using Data.BuildingsData;
using Data.PurchasesData;
using Zenject;

namespace Features.Buildings.data
{
    public class PurchaseEntitiesDaoBuildingLevelPurchasesDecorator : IPurchaseEntitiesDao
    {
        [Inject] private IBuildingsDao buildingsDao;
        [Inject(Id = IPurchaseEntitiesDao.DefaultInstance)] private IPurchaseEntitiesDao target;

        private Dictionary<BuildingType, List<PurchaseEntity>> buildingLevelPurchases;

        private Dictionary<BuildingType, List<PurchaseEntity>> BuildingLevelPurchasesMap
        {
            get
            {
                if (buildingLevelPurchases != null)
                    return buildingLevelPurchases;

                buildingLevelPurchases = buildingsDao
                    .GetBuildings()
                    .ToDictionary(
                        typeToBuilding => typeToBuilding.Key,
                        typeToBuilding => GetPurchases(typeToBuilding.Value)
                    );
                return buildingLevelPurchases;
            }
        }

        private IEnumerable<PurchaseEntity> BuildingLevelPurchasesList => BuildingLevelPurchasesMap
            .Values
            .SelectMany(list => list);

        public List<PurchaseEntity> GetEntities(string categoryId)
        {
            if (categoryId == PurchaseCategories.AllCategory)
                return target.GetEntities(categoryId).Concat(BuildingLevelPurchasesList).ToList();

            var categoryBuildingType = categoryId.PurchaseCategoryIdToBuildingType();
            if (categoryBuildingType == BuildingType.None || !buildingLevelPurchases.ContainsKey(categoryBuildingType))
                return target.GetEntities(categoryId);

            return BuildingLevelPurchasesMap[categoryBuildingType];
        }

        public PurchaseEntity FindById(string id) => BuildingLevelPurchasesList.All(entity => entity.id != id)
            ? target.FindById(id)
            : BuildingLevelPurchasesList.First(entity => entity.id == id);

        private List<PurchaseEntity> GetPurchases(BuildingEntity buildingEntity) => buildingEntity
            .skillLevels
            .Select(skillEntity => skillEntity.purchase)
            .ToList();
    }
}