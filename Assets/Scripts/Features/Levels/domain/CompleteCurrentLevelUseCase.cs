using System;
using Core.Leaderboard.domain;
using Features.Levels.domain.repositories;
using Zenject;
using Random = UnityEngine.Random;

namespace Features.Levels.domain
{
    public class CompleteCurrentLevelUseCase
    {
        [Inject] private ILevelCompletedStateRepository levelsRepository;
        [Inject] private ICurrentLevelRepository currentLevelRepository;
        [Inject] private IRewardHandler rewardHandler;
        [Inject] private SetNextCurrentLevelUseCase setNextCurrentLevelUseCase;
        [Inject] private LevelLeaderboardUseCase levelLeaderboardUseCase;

        public IObservable<bool> CompleteCurrentLevel()
        {
            var currentLevel = currentLevelRepository.GetCurrentLevel();
            setNextCurrentLevelUseCase.SetNextCurrentLevel();
            rewardHandler.HandleReward(currentLevel.Reward);
            levelsRepository.SetLevelCompleted(currentLevel.ID);
            return levelLeaderboardUseCase.SendLevelScore(currentLevel.ID, Random.Range(0, 10));
        }

        public interface IRewardHandler
        {
            void HandleReward(int amount);
        }
    }
}