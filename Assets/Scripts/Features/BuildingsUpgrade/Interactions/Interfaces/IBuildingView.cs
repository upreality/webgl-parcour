using Features.BuildingsUpgrade.Data;
using System;

namespace Features.BuildingsUpgrade.Interactions.Interfaces
{
    public interface IBuildingView
    {
        event Action<UpgradeData> OnSkillsOpen; 
        
        void OpenSkillPage(UpgradeData upgradeData);

        void UpdateSkillLevel(int activeCount, int count);
        void Initialize(UpgradeRepository upgradeRepository);
    }
}
