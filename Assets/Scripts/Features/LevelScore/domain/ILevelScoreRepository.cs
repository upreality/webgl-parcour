using Features.LevelScore.domain.model;

namespace Features.LevelScore.domain
{
    public interface ILevelScoreRepository
    {
        public int GetScore(long levelId, ScoreType type);
        public void UpdateScore(long levelId, int score);
    }
}