using System;
using System.Collections.Generic;
using System.Linq;
using Data.LevelsData;
using Features.Balance.domain;
using Features.LevelsProgression.LevelReward.domain;
using Features.LevelsProgression.LevelsScore.domain.model;
using Zenject;

namespace Features.LevelsProgression.LevelReward.data
{
    public class LevelRewardRepository : ILevelRewardRepository
    {
        [Inject] private DefaultLevelsDao levelsDao;

        public List<LevelScoreReward> GetReward(long levelId)
        {
            var index = Convert.ToInt32(levelId);
            var entity = levelsDao.levels[index];
            return entity.rewards.Select((reward, index) =>
                {
                    var pos = ((float)index) / entity.rewards.Count;
                    return GetReward(reward, pos, entity.maxScore);
                }
            ).ToList();
        }

        private static LevelScoreReward GetReward(LevelEntity.ScoreRewardData rewardData, float pos, int maxScore)
        {
            var currency = rewardData.currency == LevelEntity.CurrencyType.Coins
                ? CurrencyType.Primary
                : CurrencyType.Secondary;
            var requiredScore = Convert.ToInt32(maxScore * pos);
            return new LevelScoreReward(
                requiredScore,
                currency,
                rewardData.amount
            );
        }
    }
}