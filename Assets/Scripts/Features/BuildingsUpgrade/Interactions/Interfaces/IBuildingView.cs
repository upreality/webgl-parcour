using Features.BuildingsUpgrade.Data;
using System;
using System.Collections.Generic;

namespace Features.BuildingsUpgrade.Interactions.Interfaces
{
    public interface IBuildingView
    {
        event Action<UpgradeData> OnSkillsOpen;
        event Action<UpgradeData, int> OnBuyUpgrade;

        void OpenShop(bool value);
        void OpenSkillPage(UpgradeData upgradeData);
        void UpdateSkillLevel(int activeCount, int count);
        void Initialize(Dictionary<UpgradeData, int> upgradesDictionary);
        void UpdateView(UpgradeData upgradeData, int level);
        void DisplayInfo(UpgradeData upgradeData, Action callback);
        void BuyUpgrade(UpgradeData upgradeData, int level);
    }
}