using System;
using System.Collections.Generic;
using UnityEngine;

namespace Data.LevelsData
{
    [Serializable]
    public class LevelEntity
    {
        public int completionReward = 0;
        public int maxScore = 100;
        public int maxTimeSeconds = 60;
        public GameObject scenePrefab;
        public List<ScoreRewardData> rewards;

        public LevelEntity(int completionReward, GameObject scenePrefab)
        {
            this.completionReward = completionReward;
            this.scenePrefab = scenePrefab;
        }

        [Serializable]
        public class ScoreRewardData
        {
            public CurrencyType currency;
            public int amount;
        }
        
        public enum CurrencyType
        {
            Coins,
            Prisoners,
        }
    }
}