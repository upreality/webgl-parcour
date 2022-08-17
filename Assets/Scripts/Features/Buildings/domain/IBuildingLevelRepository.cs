using System;

namespace Features.Buildings.domain
{
    public interface IBuildingLevelRepository
    {
        
        public const string DefaultInstance = "DefIBuildingLevelRepositoryInstance";
        
        public int GetLevel(int buildingId);
        
        public IncrementLevelResult IncrementLevel(int buildingId);
        public IObservable<int> GetLevelFlow(int buildingId);
        
        public enum IncrementLevelResult
        {
            Success,
            MaxLevelReached
        }
    }
}