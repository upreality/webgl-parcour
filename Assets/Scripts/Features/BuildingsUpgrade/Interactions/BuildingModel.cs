using Features.BuildingsUpgrade.Interactions.Interfaces;
using Features.BuildingsUpgrade.Data;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace Features.BuildingsUpgrade.Interactions
{
    public class BuildingModel : IBuildingModel
    {
        public event Action<int, int> OnDataCallback = (x, y) => { };
        public event Action<UpgradeData, int> OnModelChanged = (x, y) => { };
        public event Action<Dictionary<UpgradeData, int>> OnModelInitialized = _ => { };

        private readonly Dictionary<UpgradeData, int> _upgrades = new();

        public void GetInfo(UpgradeData upgradeData)
        {
            OnDataCallback.Invoke(_upgrades[upgradeData], upgradeData.Skills.Count);
        }

        public void Initialize(UpgradeRepository upgradeRepository)
        {
            foreach (var data in upgradeRepository.UpgradeList)
            {
                var level = PlayerPrefs.GetInt("b_upgrades" + data.Name, 0);
                ChangeUpgrade(data, level);
            }

            OnModelInitialized.Invoke(_upgrades);
        }

        public void ChangeUpgrade(UpgradeData data, int level)
        {
            _upgrades[data] = level;
            PlayerPrefs.SetInt("b_upgrades" + data.Name, level);
            
            OnModelChanged.Invoke(data, level);
        }
    }
}