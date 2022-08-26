using System;
using Features.BuildingsUpgrade.Data;

namespace Features.BuildingsUpgrade.Interactions.Interfaces
{
    public interface IBuildingModel
    {
        event Action<int, int> OnDataCallback; 
        void GetInfo(UpgradeData upgradeData);
    }
}
