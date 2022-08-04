using System;
using Features.Levels.domain.model;

namespace Features.Levels.domain.repositories
{
    public interface ICurrentLevelRepository
    {
        void SetCurrentLevel(long levelId);
        Level GetCurrentLevel();
        Level GetPrevLevel();
        public IObservable<Level> GetCurrentLevelFlow();
    }
}