using System;
using Features.BuildingsUpgrade.Data;
using Features.BuildingsUpgrade.Interactions.Interfaces;
using UnityEngine;

namespace Features.BuildingsUpgrade.Interactions
{
    public class BuildingModel : IBuildingModel
    {
        public event Action<int, int> OnDataCallback = (x,y) => { };

        public void GetInfo(UpgradeData upgradeData)
        {
            Debug.Log("tut calculation");
            //До сохранений открыты все
            OnDataCallback.Invoke(3, upgradeData.Skills.Count);
        }
    }
}
