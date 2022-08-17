using System;
using Features.Balance.domain;
using Features.Purchases.data.model;
using UnityEngine;

namespace Data.BuildingsData
{
    [Serializable]
    public class SkillEntity
    {
        [Header("Description")]
        public Sprite icon;
        [Header("Russian")]
        public string ruName;
        public string ruDesc;
        [Header("English")]
        public string enName;
        public string enDesc;
        [Header("Purchase Data")] 
        public PurchaseEntity purchase;
    }
}