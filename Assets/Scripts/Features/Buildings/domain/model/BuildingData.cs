using System.Collections.Generic;
using Features.Purchases.data.model;
using UnityEngine;

namespace Features.Buildings.domain.model
{
    public struct BuildingData
    {
        public string Name;
        public string Description;
        public Sprite Image;
        public int MaxLevel;

        public List<PurchaseEntity> LevelPurchaseIds;
    }
}