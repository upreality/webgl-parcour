namespace Features.LevelsProgression.LevelsScore.domain
{
    public interface ILevelScoreRepository
    {
        public int GetScore(long levelId, ScoreType type);
        public void UpdateScore(long levelId, int score);

        enum ScoreType
        {
            Last,
            Best,
            Max
        }
    }
}