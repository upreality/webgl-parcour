using System;
using UnityEngine;

namespace Data.PurchasesData
{
    [Serializable]
    public class PurchaseEntity
    {
        public string id = Guid.NewGuid().ToString();
        public string ruName;
        public string ruDescription;
        public string enName;
        public string enDescription;
        public long passRewardLevelId = -1;
        public int currencyCost = 0;
        public bool forPrisoners = false;
        public int rewardedVideoCount = 0;
        public Sprite image;
    }
}