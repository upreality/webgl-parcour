using System;
using Levels.domain.model;

namespace Levels.domain.repositories
{
    public interface ICurrentLevelRepository
    {
        void SetCurrentLevel(long levelId);
        Level GetCurrentLevel();
        public IObservable<Level> GetCurrentLevelFlow();
    }
}