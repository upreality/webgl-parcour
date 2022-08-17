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

        public int GetLevel(int buildingId) => target.GetLevel(buildingId);

        public IObservable<int> GetLevelFlow(int buildingId) => target.GetLevelFlow(buildingId);

        public IBuildingLevelRepository.IncrementLevelResult IncrementLevel(int buildingId)
        {
            var result = target.IncrementLevel(buildingId);
            if (result != IBuildingLevelRepository.IncrementLevelResult.Success)
                return result;

            var type = buildingId.BuildingTypeFromId();
            var level = target.GetLevel(buildingId);
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
            return result;
        }
    }
}