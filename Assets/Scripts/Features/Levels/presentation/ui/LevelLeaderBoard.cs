using Core.Leaderboard.presentation;
using Features.Levels.domain.repositories;
using Zenject;

namespace Features.Levels.presentation.ui
{
    public class LevelLeaderBoard: LeaderBoardView
    {
        [Inject] private ICurrentLevelRepository currentLevelRepository;
        protected override string GetLeaderBoardId() => "LevelScore_" + currentLevelRepository.GetCurrentLevel().ID;
    }
}