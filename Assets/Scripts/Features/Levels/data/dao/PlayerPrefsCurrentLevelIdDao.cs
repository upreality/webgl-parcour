using System;
using UnityEngine;

namespace Features.Levels.data.dao
{
    public class PlayerPrefsCurrentLevelIdDataSource : CurrentLevelRepository.ICurrentLevelIdDataSource
    {
        private const string KeyPrefix = "CurrentLevelId";
        private const string PrevKeyPrefix = "PrevLevelId";

        public bool HasCurrentLevelId() => PlayerPrefs.HasKey(KeyPrefix);

        public long GetCurrentLevelId()
        {
            var storedLevelIdData = PlayerPrefs.GetString(KeyPrefix);
            return Convert.ToInt64(storedLevelIdData);
        }

        public long GetPrevLevelId()
        {
            if (!PlayerPrefs.HasKey(PrevKeyPrefix)) return GetCurrentLevelId();
            var storedLevelIdData = PlayerPrefs.GetString(PrevKeyPrefix);
            return Convert.ToInt64(storedLevelIdData);
        }

        public void SetCurrentLevelId(long id)
        {
            var prevLevelId = HasCurrentLevelId() ? GetCurrentLevelId() : id;
            PlayerPrefs.SetString(PrevKeyPrefix, prevLevelId.ToString());
            PlayerPrefs.SetString(KeyPrefix, id.ToString());
        }
    }
}