using System;
using Data.LevelsData;
using Features.LevelsProgression.LevelsScore.domain;
using Zenject;

namespace Features.LevelsProgression.LevelsScore.data
{
    public class LevelScoreRepository : ILevelScoreRepository
    {
        [Inject] private DefaultLevelsDao levelsDao;
        [Inject] private ILevelScoreDataSource levelScoreDataSource;

        public int GetScore(long levelId, ILevelScoreRepository.ScoreType type) => type switch
        {
            ILevelScoreRepository.ScoreType.Last => levelScoreDataSource.GetLastScore(levelId),
            ILevelScoreRepository.ScoreType.Best => levelScoreDataSource.GetBestScore(levelId),
            ILevelScoreRepository.ScoreType.Max => levelsDao.levels[Convert.ToInt32(levelId)].maxScore,
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, "Unknown ScoreType requested")
        };

        public void UpdateScore(long levelId, int score)
        {
            var prevScore = levelScoreDataSource.GetLastScore(levelId);
            levelScoreDataSource.SetLastScore(levelId, prevScore);
            if(score < prevScore) return;
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