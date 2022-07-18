using System;
using Plugins.FileIO;

namespace Features.Levels.data.dao
{
    public class LocalStorageCurrentLevelIdDao : CurrentLevelRepository.ICurrentLevelIdDao
    {
        private const string KeyPrefix = "CurrentLevelId";

        public bool HasCurrentLevelId() => LocalStorageIO.HasKey(KeyPrefix);

        public long GetCurrentLevelId()
        {
            var storedLevelIdData = LocalStorageIO.GetString(KeyPrefix);
            return Convert.ToInt64(storedLevelIdData);
        }

        public void SetCurrentLevelId(long id) => LocalStorageIO.SetString(KeyPrefix, id.ToString());
    }
}