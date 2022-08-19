using System;
using Data.BuildingsData;
using Features.Buildings.domain;
using Plugins.FileIO;
using UniRx;
using Zenject;

namespace Features.Buildings.data
{
    public class LocalStorageBuildingLevelRepository : IBuildingLevelRepository
    {
        [Inject] private IBuildingsDao buildingsDao;

        private readonly Subject<BuildingLevelUpdate> updates = new();

        private const string BuildingLevelKeyPrefix = "BuildingLevel_";

        public int GetLevel(string buildingId)
        {
            var key = GetBuildingLevelKey(buildingId);
            return LocalStorageIO.HasKey(key) ? LocalStorageIO.GetInt(key) : GetBuildingEntity(buildingId).defaultLevel;
        }

        public void SetLevel(string buildingId, int level)
        {
            var key = GetBuildingLevelKey(buildingId);
            LocalStorageIO.SetInt(key, level);
            var update = new BuildingLevelUpdate
            {
                BuildingId = buildingId,
                Level = level
            };
            updates.OnNext(update);
        }

        public IObservable<int> GetLevelFlow(string buildingId)
        {
            var initialLevel = GetLevel(buildingId);
            return updates
                .Where(update => update.BuildingId == buildingId)
                .Select(update => update.Level)
                .StartWith(initialLevel);
        }

        private BuildingEntity GetBuildingEntity(string buildingId)
        {
            var type = buildingId.IdToBuildingType();
            return buildingsDao.GetBuilding(type);
        }

        private static string GetBuildingLevelKey(string buildingId) => BuildingLevelKeyPrefix + buildingId;

        private struct BuildingLevelUpdate
        {
            public string BuildingId;
            public int Level;
        }
    }
}