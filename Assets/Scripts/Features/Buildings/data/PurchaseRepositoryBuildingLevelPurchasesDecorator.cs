using System;
using System.Collections.Generic;
using System.Linq;
using Data.BuildingsData;
using Data.PurchasesData;
using Features.Purchases.data;
using Features.Purchases.domain.model;
using Features.Purchases.domain.repositories;
using Zenject;

namespace Features.Buildings.data
{
    public class PurchaseRepositoryBuildingLevelPurchasesDecorator : IPurchaseRepository
    {
        [Inject] private IBuildingsDao buildingsDao;
        [Inject] private IPurchaseRepository target;
        [Inject] private PurchaseEntityConverter purchaseEntityConverter;

        private Dictionary<BuildingType, List<Purchase>> buildingLevelPurchases;
        private Dictionary<BuildingType, List<Purchase>> BuildingLevelPurchases
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

        public List<Purchase> GetPurchases(string categoryId)
        {
            if (categoryId == PurchaseCategories.AllCategory)
            {
                var buildingsLevelsPurchases = BuildingLevelPurchases.Values.SelectMany(list => list);
                return target.GetPurchases(categoryId).Concat(buildingsLevelsPurchases).ToList();
            }

            var categoryBuildingType = categoryId.PurchaseCategoryIdToBuildingType();
            if (categoryBuildingType == BuildingType.None || !buildingLevelPurchases.ContainsKey(categoryBuildingType))
                return target.GetPurchases(categoryId);

            return buildingLevelPurchases[categoryBuildingType];
        }

        public Purchase GetById(string id) => target.GetById(id);

        private List<Purchase> GetPurchases(BuildingEntity buildingEntity) => buildingEntity
            .skillLevels
            .Select(skillEntity => skillEntity.purchase)
            .Select(purchaseEntityConverter.GetPurchaseFromEntity)
            .ToList();
    }
}