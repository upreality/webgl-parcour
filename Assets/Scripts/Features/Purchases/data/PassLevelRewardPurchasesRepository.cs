using System.Linq;
using Data.PurchasesData;
using Features.Purchases.domain.model;
using Features.Purchases.domain.repositories;
using Zenject;

namespace Features.Purchases.data
{
    public class PassLevelRewardPurchasesRepository : IPassLevelRewardPurchasesRepository
    {
        [Inject] private IPurchaseEntitiesDao entitiesDao;
        [Inject] private PurchaseEntityConverter converter;

        public bool HasForLevel(long levelId) => entitiesDao
            .GetEntities(PurchaseCategories.AllCategory)
            .Any(entity => entity.passRewardLevelId == levelId);

        public long GetLevelId(string purchaseId) => entitiesDao.FindById(purchaseId).passRewardLevelId;

        public Purchase GetForLevel(long levelId)
        {
            var entity = entitiesDao
                .GetEntities(PurchaseCategories.AllCategory)
                .Where(entity => entity.GetPurchaseType() == PurchaseType.PassLevelReward)
                .First(entity => entity.passRewardLevelId == levelId);

            return converter.GetPurchaseFromEntity(entity);
        }
    }
}