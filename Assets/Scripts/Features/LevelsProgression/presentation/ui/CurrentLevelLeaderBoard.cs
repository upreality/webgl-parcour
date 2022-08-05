using System;
using System.Collections.Generic;
using Core.Leaderboard.domain;
using Core.Leaderboard.presentation;
using Features.Levels.domain.repositories;
using Features.LevelsProgression.domain;
using Zenject;

namespace Features.LevelsProgression.presentation.ui
{
    public class CurrentLevelLeaderBoard: LeaderBoardView
    {
        [Inject] private ICurrentLevelRepository currentLevelRepository;
        [Inject] private CurrentLevelLeaderBoardUseCase currentLevelLeaderBoardUseCase;
        
        protected override IObservable<List<LeaderBoardItem>> GetLeaderBoardResultsFlow() => currentLevelLeaderBoardUseCase.GetLeaderBoardResultsFlow();
    }
}