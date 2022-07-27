using System.Collections.Generic;
using Features.Purchases.domain.model;

namespace Features.Purchases.domain.repositories
{
    public interface IPurchaseRepository
    {
        public List<Purchase> GetPurchases();
        public Purchase GetById(long id);
    }
}