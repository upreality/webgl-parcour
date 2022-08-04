using System;
using System.Collections.Generic;
using UnityEngine;

namespace Data.LevelsData
{
    [Serializable]
    public class LevelEntity
    {
        public int reward = 0;
        public int maxScore = 0;
        public GameObject scenePrefab;
        public List<ScoreRewardData> rewards;

        public LevelEntity(int reward, GameObject scenePrefab)
        {
            this.reward = reward;
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
            Civilians,
        }
    }
}