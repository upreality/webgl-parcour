using System;
using System.Collections.Generic;
using Core.Leaderboard.domain;
using Zenject;

namespace Features.Levels.domain
{
    public class LevelLeaderboardUseCase
    {
        [Inject] private LeaderBoardUseCase leaderBoardUseCase;

        public IObservable<List<LeaderBoardItem>> GetPositionsAroundPlayer(long levelId)
        {
            var leaderBoardName = GetLeaderBoardName(levelId);
            return leaderBoardUseCase.GetPositionsAroundPlayer(leaderBoardName);
        }

        public IObservable<bool> SendLevelScore(long levelId, int score)
        {
            var leaderBoardName = GetLeaderBoardName(levelId);
            return leaderBoardUseCase.SendResult(leaderBoardName, score);
        }

        private string GetLeaderBoardName(long levelId) => "LevelScore_" + levelId;
    }
}