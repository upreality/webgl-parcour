using System;

namespace Features.Buildings.domain
{
    public interface IBuildingLevelRepository
    {
        
        public const string DefaultInstance = "DefIBuildingLevelRepositoryInstance";
        
        public int GetLevel(string buildingId);
        
        public IncrementLevelResult IncrementLevel(string buildingId);
        public IObservable<int> GetLevelFlow(string buildingId);
        
        public enum IncrementLevelResult
        {
            Success,
            MaxLevelReached
        }
    }
}