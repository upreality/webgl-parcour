using System;
using System.Collections.Generic;
using Core.Auth.domain;
using Core.Leaderboard.domain;
using UniRx;
using Zenject;

namespace Core.Leaderboard.data
{
    public class LeaderBoardPlayfabRepository : ILeaderBoardRepository
    {
        [Inject] private IAuthRepository authRepository;
        [Inject] private ILeaderBoardRemoteDataSource leaderBoardRemoteDataSource;

        private const int MAX_RESULTS_COUNT = 10;

        public IObservable<List<LeaderBoardItem>> GetPositionsAroundPlayer(string leaderBoardId) => authRepository
            .GetLoggedInFlow()
            .Where(loggedIn => loggedIn)
            .Select(_ => leaderBoardRemoteDataSource.GetPositionsAroundPlayer(leaderBoardId, MAX_RESULTS_COUNT))
            .Switch();

        public IObservable<bool> SendResult(string leaderBoardId, int score) => authRepository
            .GetLoggedInFlow()
            .Where(loggedIn => loggedIn)
            .Select(_ => leaderBoardRemoteDataSource.SendResult(leaderBoardId, score))
            .Switch();

        public interface ILeaderBoardRemoteDataSource
        {
            IObservable<List<LeaderBoardItem>> GetPositionsAroundPlayer(string leaderBoardId, int resultsCount);
            IObservable<bool> SendResult(string leaderBoardId, int score);
        }
    }
}