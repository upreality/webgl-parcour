using System;
using Data.BuildingsData;
using Features.Buildings.domain;
using Plugins.FileIO;
using UniRx;
using Zenject;
using static Features.Buildings.domain.IBuildingLevelRepository;

namespace Features.Buildings.data
{
    public class LocalStorageBuildingLevelRepository : IBuildingLevelRepository
    {
        [Inject] private IBuildingsDao buildingsDao;

        private readonly Subject<BuildingLevelUpdate> updates = new();

        private const string BuildingLevelKeyPrefix = "BuildingLevel_";

        public int GetLevel(int buildingId)
        {
            var key = GetBuildingLevelKey(buildingId);
            return LocalStorageIO.HasKey(key) ? LocalStorageIO.GetInt(key) : GetBuildingEntity(buildingId).defaultLevel;
        }

        public IncrementLevelResult IncrementLevel(int buildingId)
        {
            var maxLevel = GetBuildingEntity(buildingId).skillLevels.Count;
            var currentLevel = GetLevel(buildingId);
            if (currentLevel >= maxLevel)
                return IncrementLevelResult.MaxLevelReached;

            currentLevel++;
            var key = GetBuildingLevelKey(buildingId);
            LocalStorageIO.SetInt(key, currentLevel);
            var update = new BuildingLevelUpdate
            {
                BuildingId = buildingId,
                Level = currentLevel
            };
            updates.OnNext(update);
            return IncrementLevelResult.Success;
        }

        public IObservable<int> GetLevelFlow(int buildingId)
        {
            var initialLevel = GetLevel(buildingId);
            return updates
                .Where(update => update.BuildingId == buildingId)
                .Select(update => update.Level)
                .StartWith(initialLevel);
        }

        private BuildingEntity GetBuildingEntity(int buildingId)
        {
            var type = buildingId.BuildingTypeFromId();
            return buildingsDao.GetBuilding(type);
        }

        private static string GetBuildingLevelKey(int buildingId) => BuildingLevelKeyPrefix + buildingId;

        private struct BuildingLevelUpdate
        {
            public int BuildingId;
            public int Level;
        }
    }
}