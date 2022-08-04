using System.Collections.Generic;
using Features.LevelsProgression.LevelsScore.domain.model;

namespace Features.LevelsProgression.LevelReward.domain
{
    public interface ILevelRewardRepository
    {
        public List<LevelScoreReward> GetReward(long levelId);
    }
}