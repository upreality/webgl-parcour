using System.Collections.Generic;
using Features.Purchases.data.model;

namespace Features.Purchases.data
{
    public interface IPurchaseEntitiesDao
    {
        public List<PurchaseEntity> GetLevelEntities();

        public PurchaseEntity FindById(long id);
    }
}