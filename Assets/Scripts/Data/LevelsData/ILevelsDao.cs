using System.Collections.Generic;

namespace Data.LevelsData
{
    public interface ILevelsDao
    {
        public Dictionary<long, LevelEntity> GetLevels();
        LevelEntity GetLevel(long levelId);
    }
}