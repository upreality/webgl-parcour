using System.Collections.Generic;
using System.Linq;
using Data.PurchasesData;
using Features.Purchases.domain.model;
using Features.Purchases.domain.repositories;
using Zenject;

namespace Features.Purchases.data
{
    public class PurchaseRepository : IPurchaseRepository
    {
        [Inject] private IPurchaseEntitiesDao entitiesDao;
        [Inject] private PurchaseEntityConverter converter;

        public List<Purchase> GetPurchases(string categoryId = PurchaseCategories.DefaultCategory) => entitiesDao
            .GetEntities(categoryId)
            .Select(converter.GetPurchaseFromEntity)
            .ToList();

        public Purchase GetById(string id)
        {
            var purchaseEntity = entitiesDao.FindById(id);
            return converter.GetPurchaseFromEntity(purchaseEntity);
        }
    }
}