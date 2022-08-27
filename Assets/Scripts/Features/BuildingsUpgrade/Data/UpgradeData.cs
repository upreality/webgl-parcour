using System;
using System.Collections.Generic;
using UnityEngine;

namespace Features.BuildingsUpgrade.Data
{
    [Serializable]
    public class UpgradeData
    {
        [field: SerializeField]
        public int Price { get; private set; }
        
        [field: SerializeField]
        public string Name { get; private set; }

        [field: SerializeField]
        public Sprite Sprite { get; private set; }
        
        [field: SerializeField]
        public Vector3 BuildingPosition { get; private set; }

        [field: SerializeField, NonReorderable]
        public List<SkillData> Skills { get; private set; }


    }
}