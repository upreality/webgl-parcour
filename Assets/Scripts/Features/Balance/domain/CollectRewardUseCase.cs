using Features.Balance.domain.repositories;
using Zenject;

namespace Features.Balance.domain
{
    public class CollectRewardUseCase
    {
        [Inject] private IBalanceRepository balanceRepository;
        [Inject] private IRewardRepository rewardRepository;

        public void Collect(float multiplier = 1f)
        {
            var collected = (int) (rewardRepository.Get() * multiplier);
            balanceRepository.Add(collected, CurrencyType.Primary);
            rewardRepository.Drop();
        }
    }
}