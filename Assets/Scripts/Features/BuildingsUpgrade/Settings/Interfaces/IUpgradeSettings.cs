using Features.BuildingsUpgrade.Interactions;
using Features.BuildingsUpgrade.Pages;
using UnityEngine;
using UnityEngine.UI;

namespace Features.BuildingsUpgrade.Settings.Interfaces
{
    public interface IUpgradeSettings
    {
        Image ShopPanel { get; }

        Button CloseButton { get; }
        
        BuildingUpgradeChannel UpgradeChannel { get;}
        
        BuildingInteractionChannel InteractionChannel { get; }

        Transform ButtonsHandler { get; }

        MonoBuildingButton ButtonPrefab { get; }
        
        MonoUpgradePage FirstPage { get; }
        
        MonoSkillPage SecondPage { get; }
    }
}