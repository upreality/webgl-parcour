using System;
using System.Collections.Generic;
using Core.Leaderboard.domain;
using Features.Levels.domain.repositories;
using Zenject;

namespace Features.LevelsProgression.domain
{
    public class CurrentLevelLeaderBoardUseCase
    {
        [Inject] private ICurrentLevelRepository currentLevelRepository;
        [Inject] private LevelLeaderboardUseCase levelLeaderboardUseCase;

        public IObservable<List<LeaderBoardItem>> GetLeaderBoardResultsFlow()
        {
            var currentLevel = currentLevelRepository.GetCurrentLevel().ID;
            return levelLeaderboardUseCase.GetPositionsAroundPlayer(currentLevel);
        }
    }
}