using System;
using Core.Leaderboard.domain;
using Features.GlobalScore.domain;
using Zenject;

namespace Features.GlobalScore.data
{
    public class PlayfabGlobalScoreRepository : IGlobalScoreRepository
    {
        [Inject] private ILeaderBoardRepository leaderBoardRepository;
        [Inject] private GlobalScoreLocalDataSource localDataSource;

        private const string LEADER_BOARD_NAME = "GlobalScore";

        public IObservable<int> GetScore() => localDataSource.GetScore();

        public IObservable<bool> SendScore(int score)
        {
            localDataSource.SendScore(score);
            return leaderBoardRepository.SendResult(LEADER_BOARD_NAME, score);
        }
    }
}