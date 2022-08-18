using Data.PurchasesData;
using Features.Purchases.domain.model;

namespace Features.Purchases.data
{
    public static class PurchaseEntityExtensions
    {
        public static PurchaseType GetPurchaseType(this PurchaseEntity entity)
        {
            if (entity.passRewardLevelId > 0)
                return PurchaseType.PassLevelReward;

            if (entity.rewardedVideoCount > 0)
                return PurchaseType.RewardedVideo;

            return entity.forPrisoners ? PurchaseType.Prisoners : PurchaseType.Coins;
        }
    }
}