using System.Collections.Generic;

namespace Data.PurchasesData
{
    public interface IPurchaseEntitiesDao
    {
        public const string DefaultInstance = "DefIPurchaseEntitiesDaoInstance";
        
        public List<PurchaseEntity> GetEntities(string categoryId);

        public PurchaseEntity FindById(string id);
    }
}