using System;
using Features.LevelTime.domain;
using UniRx;
using Zenject;

namespace Features.LevelsProgression.domain
{
    public class CurrentScoreUseCase
    {
        [Inject] private ILevelTimerRepository levelTimerRepository;

        public int GetLastScore() => CalculateScore(levelTimerRepository.GetTimerResult());

        public IObservable<int> GetCurrentScoreFlow() => levelTimerRepository
            .GetTimerFlow()
            .Select(CalculateScore);

        private static int CalculateScore(long timer) => Convert.ToInt32(timer);
    }
}