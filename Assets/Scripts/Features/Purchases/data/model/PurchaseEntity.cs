using System;
using Features.Balance.domain;
using Features.Purchases.domain.model;
using UnityEngine;

namespace Features.Purchases.data.model
{
    [Serializable]
    public class PurchaseEntity
    {
        public string id;
        public string ruName;
        public string ruDescription;
        public string enName;
        public string enDescription;
        public long passRewardLevelId = -1;
        public CurrencyType currency = CurrencyType.Primary;
        public int currencyCost = 0;
        public int rewardedVideoCount = 1;
        public PurchaseType type;
        public Sprite image;
    }
}