using System;
using System.Collections.Generic;

namespace Core.Leaderboard.domain
{
    interface ILeaderBoardRepository
    {
        IObservable<List<LeaderBoardItem>> GetPositionsAroundPlayer(string leaderBoardId);
        IObservable<bool> SendResult(string leaderBoardId, int score);
    }
}