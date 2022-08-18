using System;
using UniRx;
using Zenject;
using static Features.Buildings.domain.BuildingProgressStateUseCase.BuildingProgress;

namespace Features.Buildings.domain
{
    public class BuildingProgressStateUseCase
    {
        [Inject(Id = IBuildingLevelRepository.DefaultInstance)]
        private IBuildingLevelRepository levelRepository;

        [Inject] private IBuildingDataRepository dataRepository;

        public BuildingProgressState GetState(string buildingId)
        {
            var currentLevel = levelRepository.GetLevel(buildingId);
            var progress = GetProgress(buildingId, currentLevel);
            return new BuildingProgressState
            {
                Progress = progress,
                Level = currentLevel
            };
        }

        public IObservable<BuildingProgressState> GetStateFlow(string buildingId) => levelRepository
            .GetLevelFlow(buildingId)
            .Select(level => new BuildingProgressState
            {
                Progress = GetProgress(buildingId, level),
                Level = level
            });

        private BuildingProgress GetProgress(string buildingId, int currentLevel)
        {
            if (currentLevel < 1)
                return NotBuilt;

            var maxLevel = dataRepository.GetBuilding(buildingId).MaxLevel;
            return currentLevel < maxLevel ? UpgradeAvailable : CompletelyUpgraded;
        }

        public struct BuildingProgressState
        {
            public BuildingProgress Progress;
            public int Level;
        }

        public enum BuildingProgress
        {
            NotBuilt,
            UpgradeAvailable,
            CompletelyUpgraded
        }
    }
}