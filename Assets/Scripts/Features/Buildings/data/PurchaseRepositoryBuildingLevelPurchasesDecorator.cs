using System.Collections.Generic;
using Data.BuildingsData;
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
            
        }

        public Purchase GetById(string id)
        {
            
        }
    }
}