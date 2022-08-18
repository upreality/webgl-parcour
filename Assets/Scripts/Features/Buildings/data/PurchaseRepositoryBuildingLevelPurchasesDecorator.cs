using System.Collections.Generic;
using System.Linq;
using Data.BuildingsData;
using Data.PurchasesData;
using Features.Purchases.domain.model;
using Features.Purchases.domain.repositories;
using Zenject;

namespace Features.Buildings.data
{
    public class PurchaseRepositoryBuildingLevelPurchasesDecorator: IPurchaseRepository
    {
        [Inject] private IBuildingsDao buildingsDao;
        [Inject] private IPurchaseRepository target;
        public List<Purchase> GetPurchases(string categoryId)
        {
            if(categoryId == PurchaseCategories.AllCategory)
                return buildingsDao.GetBuildings().Select()
            
                    
                    
                    
                    
            var buildingLevelPurchasesCategories = buildingsDao
                .GetBuildings()
                .Keys
                .Select(BuildingTypeExtensions.ToPurchaseCategoryId);
        }

        public Purchase GetById(string id) => target.GetById(id);
    }
}