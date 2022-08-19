using System;

namespace Features.Buildings.domain
{
    public interface IBuildingLevelRepository
    {
        
        public const string DefaultInstance = "DefIBuildingLevelRepositoryInstance";
        
        public void SetLevel(string buildingId, int level);
        public int GetLevel(string buildingId);
        public IObservable<int> GetLevelFlow(string buildingId);
    }
}