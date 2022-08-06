using System.Collections.Generic;
using Features.LevelReward.data.model;

namespace Features.LevelReward.domain
{
    public interface ILevelRewardRepository
    {
        public List<LevelScoreReward> GetReward(long levelId);
    }
}