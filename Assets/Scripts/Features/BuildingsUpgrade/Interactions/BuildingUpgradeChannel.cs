using UnityEngine;
using System;

namespace Features.BuildingsUpgrade.Interactions
{
    [CreateAssetMenu(fileName = "BuildingUpgrade")]
    public class BuildingUpgradeChannel : ScriptableObject
    {
        private event Action<bool> OnInteraction = _ => { };
        
        public void Fire(bool value)
        {
            OnInteraction.Invoke(value);
        }

        public void AddListener(Action<bool> action)
        {
            OnInteraction += action;
        }

        public void RemoveListener(Action<bool> action)
        {
            OnInteraction -= action;
        }
    }
}
