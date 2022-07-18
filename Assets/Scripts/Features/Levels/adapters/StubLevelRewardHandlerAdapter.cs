using Features.Levels.domain;

namespace Features.Levels.adapters
{
    public class StubLevelRewardHandlerAdapter : CompleteCurrentLevelUseCase.IRewardHandler
    {
        public void HandleReward(int amount)
        {
        }
    }
}