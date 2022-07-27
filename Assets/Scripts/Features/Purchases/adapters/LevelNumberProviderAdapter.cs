using Features.Levels.domain.repositories;
using Features.Purchases.domain.repositories;
using Features.Purchases.presentation.ui;
using Zenject;

namespace Features.Purchases.adapters
{
    public class LevelNumberProviderAdapter : PassLevelRewardPurchaseItem.ILevelNumberProvider
    {
        [Inject] private IPassLevelRewardPurchasesRepository passLevelRewardPurchasesRepository;
        [Inject] private ILevelsRepository levelsRepository;

        public int GetLevelNumber(long purchaseId)
        {
            var targetLevelId = passLevelRewardPurchasesRepository.GetLevelId(purchaseId);
            return levelsRepository.GetLevel(targetLevelId).Number;
        }
    }
}