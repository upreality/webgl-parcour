using System;
using Data.LevelsData;
using Features.LevelScore.domain;
using Features.LevelScore.domain.model;
using Zenject;

namespace Features.LevelScore.data
{
    public class LevelScoreRepository : ILevelScoreRepository
    {
        [Inject] private ILevelsDao levelsDao;
        [Inject] private ILevelScoreDataSource levelScoreDataSource;

        public int GetScore(long levelId, ScoreType type) => type switch
        {
            ScoreType.Last => levelScoreDataSource.GetLastScore(levelId),
            ScoreType.Best => levelScoreDataSource.GetBestScore(levelId),
            ScoreType.Max => levelsDao.GetLevel(levelId).maxScore,
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, "Unknown ScoreType requested")
        };

        public void UpdateScore(long levelId, int score)
        {
            var prevScore = levelScoreDataSource.GetLastScore(levelId);
            levelScoreDataSource.SetLastScore(levelId, score);
            if (score < prevScore) return;
            levelScoreDataSource.SetBestScore(levelId, score);
        }

        public interface ILevelScoreDataSource
        {
            public int GetBestScore(long levelId);
            public int GetLastScore(long levelId);
            public void SetBestScore(long levelId, int score);
            public void SetLastScore(long levelId, int score);
        }
    }
}