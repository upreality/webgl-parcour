using System;
using System.Collections.Generic;
using System.Linq;
using Features.Levels.domain;
using Features.Levels.domain.model;
using Features.LevelScore.domain;
using Features.LevelScore.domain.model;
using UniRx;
using Zenject;

namespace Features.GlobalScore.domain
{
    public class CalculateGlobalScoreUseCase
    {
        [Inject] private IGlobalScoreRepository globalScoreRepository;
        [Inject] private ILevelScoreRepository scoreRepository;
        [Inject] private GetCompletedLevelsUseCase completedLevelsUseCase;

        public int GetScore()
        {
            var completedLevels = completedLevelsUseCase.GetCompletedLevels();
            return GetScore(completedLevels);
        }

        public IObservable<int> GetScoreFlow() => completedLevelsUseCase
            .GetCompletedLevelsFlow()
            .Select(GetScore);

        private int GetScore(IEnumerable<Level> levels) => levels
            .Select(level => scoreRepository.GetScore(level.ID, ScoreType.Best))
            .Sum();
    }
}