using System.Linq;
using Features.Purchases.domain.model;
using Features.Purchases.domain.repositories;
using Zenject;

namespace Features.Purchases.data
{
    public class PassLevelRewardPurchasesRepository : IPassLevelRewardPurchasesRepository
    {
        [Inject] private IPurchaseEntitiesDao entitiesDao;
        [Inject] private PurchaseEntityConverter converter;

        public bool HasForLevel(long levelId)
        {
            return entitiesDao.GetLevelEntities().Any(entity => entity.passRewardLevelId == levelId);
        }

        public long GetLevelId(long purchaseId)
        {
            return entitiesDao.FindById(purchaseId).passRewardLevelId;
        }

        public Purchase GetForLevel(long levelId)
        {
            var entity = entitiesDao
                .GetLevelEntities()
                .Where(entity => entity.Type == PurchaseType.PassLevelReward)
                .First(entity => entity.passRewardLevelId == levelId);

            return converter.GetPurchaseFromEntity(entity);
        }
    }
}