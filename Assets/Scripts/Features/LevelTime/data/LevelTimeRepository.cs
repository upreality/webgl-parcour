using Data.LevelsData;
using Features.LevelTime.domain;
using Zenject;

namespace Features.LevelTime.data
{
    public class LevelTimeRepository: ILevelTimeRepository
    {
        [Inject] private ILevelsDao levelsDao;
        
        public int GetMaxTime(long levelID) => levelsDao.GetLevel(levelID).maxTimeSeconds;
    }
}