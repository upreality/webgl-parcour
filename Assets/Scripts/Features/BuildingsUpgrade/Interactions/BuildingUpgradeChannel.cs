using Features.BuildingsUpgrade.Data;
using UnityEngine;
using System;

namespace Features.BuildingsUpgrade.Interactions
{
    [CreateAssetMenu(fileName = "BuildingUpgradeChannel")]
    public class BuildingUpgradeChannel : ScriptableObject
    {
        private event Action<UpgradeData, int> OnUpgrade = (x,y) => { };
        public event Action OnInitialized = () => { };

        public void Fire(UpgradeData value, int num)
        {
            OnUpgrade.Invoke(value, num);
        }

        public void AddListener(Action<UpgradeData, int> action)
        {
            OnUpgrade += action;
        }

        public void RemoveListener(Action<UpgradeData, int> action)
        {
            OnUpgrade -= action;
        }

        public void Initialize()
        {
            OnInitialized.Invoke();
        }
    }
}
