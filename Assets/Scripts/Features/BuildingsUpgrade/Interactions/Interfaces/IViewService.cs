using System;
using Features.BuildingsUpgrade.Data;

namespace Features.BuildingsUpgrade.Interactions.Interfaces
{
    public interface IViewService
    {
        event Action<UpgradeData> OnOpenView;
    }
}
