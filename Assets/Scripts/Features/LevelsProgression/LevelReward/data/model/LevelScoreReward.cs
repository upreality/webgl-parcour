using Features.Balance.domain;

namespace Features.LevelsProgression.LevelsScore.domain.model
{

    public class LevelScoreReward
    {
        public int RequiredScore;
        public CurrencyType Currency;
        public int Amount;

        public LevelScoreReward(int requiredScore, CurrencyType currency, int amount)
        {
            RequiredScore = requiredScore;
            Currency = currency;
            Amount = amount;
        }
    }
}