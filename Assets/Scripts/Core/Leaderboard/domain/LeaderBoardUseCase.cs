using System;
using System.Collections.Generic;
using Core.Auth.domain;
using UniRx;
using Zenject;

namespace Core.Leaderboard.domain
{
    public class LeaderBoardUseCase
    {
        [Inject] private IAuthRepository authRepository;
        [Inject] private ILeaderBoardRepository leaderBoardRepository;

        public IObservable<List<LeaderBoardItem>> GetPositionsAroundPlayer(string leaderBoardId) => authRepository
            .GetLoggedInFlow()
            .Where(loggedIn => loggedIn)
            .Select(_ => leaderBoardRepository.GetPositionsAroundPlayer(leaderBoardId))
            .Switch();

        public IObservable<bool> SendResult(string leaderBoardId, int score) => authRepository
            .GetLoggedInFlow()
            .Where(loggedIn => loggedIn)
            .Select(_ => leaderBoardRepository.SendResult(leaderBoardId, score))
            .Switch();
    }
}