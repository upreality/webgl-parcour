using Data.LevelsData;
using Features.LevelScore.domain;
using Zenject;

namespace Features.LevelScore.data
{
    public class LevelMaxScoreRepository : ILevelMaxScoreRepository
    {
        [Inject] private ILevelsDao levelsDao;

        public int GetMaxScore(long levelId) => levelsDao.GetLevel(levelId).maxScore;
    }
}