using System.Collections.Generic;
using System.Linq;
using Data.BuildingsData;
using Features.Purchases.data;
using Features.Purchases.data.model;
using Features.Purchases.domain.model;
using Features.Purchases.domain.repositories;
using Zenject;

namespace Features.Buildings.data
{
    public class BuildingLevelPurchaseRepository : IPurchaseRepository
    {
        [Inject] private IBuildingsDao buildingsDao;
        [Inject] private PurchaseEntityConverter purchaseEntityConverter;

        [Inject] private BuildingType buildingType;

        public List<Purchase> GetPurchases() => GetPurchaseEntities()
            .Select(purchaseEntityConverter.GetPurchaseFromEntity)
            .ToList();

        private IEnumerable<PurchaseEntity> GetPurchaseEntities() => buildingsDao
            .GetBuilding(buildingType)
            .skillLevels
            .Select(skill => skill.purchase);

        public Purchase GetById(long id)
        {
            var purchaseEntity = GetPurchaseEntities().First(entity => entity.Id == id);
            return purchaseEntityConverter.GetPurchaseFromEntity(purchaseEntity);
        }
    }
}