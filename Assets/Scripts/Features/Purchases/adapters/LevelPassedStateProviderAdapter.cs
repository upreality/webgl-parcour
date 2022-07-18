using System;
using Features.Levels.domain.repositories;
using Features.Purchases.domain;
using Zenject;

namespace Features.Purchases.adapters
{
    public class LevelPassedStateProviderAdapter : ILevelPassedStateProvider
    {
        [Inject] private ILevelCompletedStateRepository completedStateRepository;

        public IObservable<bool> GetLevelPassedState(long levelId) => completedStateRepository
            .GetLevelCompletedState(levelId);
    }
}