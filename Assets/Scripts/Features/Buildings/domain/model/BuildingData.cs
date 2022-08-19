using System.Collections.Generic;
using Features.Purchases.domain.model;
using UnityEngine;

namespace Features.Buildings.domain.model
{
    public struct BuildingData
    {
        public string Id;
        public string Name;
        public string Description;
        public Sprite Image;
        public List<Purchase> LevelPurchases;
    }
}