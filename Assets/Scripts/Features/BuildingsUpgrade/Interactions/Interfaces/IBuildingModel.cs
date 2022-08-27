using System;
using System.Collections.Generic;
using Features.BuildingsUpgrade.Data;

namespace Features.BuildingsUpgrade.Interactions.Interfaces
{
    public interface IBuildingModel
    {
        event Action<int, int> OnDataCallback;
        event Action<UpgradeData, int> OnModelChanged;
        event Action<Dictionary<UpgradeData, int>> OnModelInitialized;
        void ChangeUpgrade(UpgradeData data, int level);
        void GetInfo(UpgradeData upgradeData);
        void Initialize(UpgradeRepository upgradeRepository);
    }
}
