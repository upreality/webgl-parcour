using System;
using System.Collections.Generic;
using Data.BuildingsData;
using Features.Buildings.domain;
using PlayFab;
using PlayFab.ClientModels;
using Zenject;

namespace Features.Buildings.data
{
    public class BuildingLevelRepositoryPlayfabStatDecorator : IBuildingLevelRepository
    {
        [Inject] private IBuildingLevelRepository target;

        public void SetLevel(string buildingId, int level)
        {
            var type = buildingId.IdToBuildingType();
            var request = new UpdatePlayerStatisticsRequest
            {
                Statistics = new List<StatisticUpdate>
                {
                    new()
                    {
                        StatisticName = "Building_" + type + "_Level",
                        Value = level
                    }
                }
            };
            PlayFabClientAPI.UpdatePlayerStatistics(request, _ => { }, _ => { });
            target.SetLevel(buildingId, level);
        }

        public int GetLevel(string buildingId) => target.GetLevel(buildingId);

        public IObservable<int> GetLevelFlow(string buildingId) => target.GetLevelFlow(buildingId);
    }
}