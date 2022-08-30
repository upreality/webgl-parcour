using Features.BuildingsUpgrade.Data;
using UnityEngine;
using System;

namespace Features.BuildingsUpgrade.Interactions
{
    [CreateAssetMenu(fileName = "BuildingUpgrade")]
    public class BuildingInteractionChannel : ScriptableObject
    {
        private event Action<UpgradeData> OnInteraction = _ => { };

        public void Fire(UpgradeData value)
        {
            Debug.Log(value);
            OnInteraction.Invoke(value ? value : null);
        }

        public void AddListener(Action<UpgradeData> action)
        {
            OnInteraction += action;
        }

        public void RemoveListener(Action<UpgradeData> action)
        {
            OnInteraction -= action;
        }
    }
}