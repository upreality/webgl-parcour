using Features.BuildingsUpgrade.Settings.Interfaces;
using Features.BuildingsUpgrade.Interactions;
using UnityEngine.UI;
using UnityEngine;
using System;
using Features.BuildingsUpgrade.Pages;

namespace Features.BuildingsUpgrade.Settings
{
    [Serializable]
    public class UpgradeSettings : IUpgradeSettings
    {
        [field: SerializeField] 
        public BuildingInteractionChannel InteractionChannel { get; private set; }
        
        [field: SerializeField] 
        public BuildingUpgradeChannel UpgradeChannel { get; private set; }

        [field: SerializeField] 
        public Image ShopPanel { get; private set; }

        [field: SerializeField]
        public MonoBuildingButton ButtonPrefab { get; private set; }

        [field: SerializeField] 
        public Transform ButtonsHandler { get; private set; }

        [field: SerializeField] 
        public Button CloseButton { get; private set; }
        
        [field: SerializeField]
        public MonoUpgradePage FirstPage { get; private set; }
        
        [field: SerializeField]
        public MonoSkillPage SecondPage { get; private set; }
    }
}