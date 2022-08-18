using System.Collections.Generic;
using System.Linq;
using Features.Purchases.data.model;
using UnityEngine;

namespace Features.Purchases.data.dao
{
    [CreateAssetMenu(menuName = "Purchases/PurchasesDao/SimplePurchaseEntitiesDao")]
    public class SimplePurchaseEntitiesDao: ScriptableObject, IPurchaseEntitiesDao
    {
        [SerializeField]
        private List<PurchaseEntity> entities = new();

        public List<PurchaseEntity> GetLevelEntities() => entities;
        
        public PurchaseEntity FindById(string id) => entities.First(entity => entity.id == id);
    }
}