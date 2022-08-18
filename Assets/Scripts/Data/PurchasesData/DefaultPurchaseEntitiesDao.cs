using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Data.PurchasesData
{
    [CreateAssetMenu(menuName = "Purchases/DefaultPurchaseEntitiesDao")]
    public class DefaultPurchaseEntitiesDao: ScriptableObject, IPurchaseEntitiesDao
    {
        [SerializeField]
        private List<PurchaseEntity> entities = new();

        public List<PurchaseEntity> GetEntities(string categoryId)
        {
            return categoryId is PurchaseCategories.DefaultCategory or PurchaseCategories.AllCategory 
                ? entities 
                : new List<PurchaseEntity>();
        }

        public PurchaseEntity FindById(string id) => entities.First(entity => entity.id == id);
    }
}