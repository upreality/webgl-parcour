using Core.Analytics.adapter;
using Core.Analytics.levels;
using Features.Balance.domain;
using Features.Balance.domain.repositories;
using Features.Levels.domain;
using Features.Levels.domain.repositories;
using Features.LevelTime.domain;
using Zenject;

namespace Features.LevelsProgression.domain
{
    public class CompleteCurrentLevelUseCase
    {
        [Inject] private AnalyticsAdapter analytics;
        [Inject] private ILevelCompletedStateRepository levelsRepository;
        [Inject] private ICurrentLevelRepository currentLevelRepository;
        [Inject] private IBalanceRepository balanceRepository;
        [Inject] private ILevelTimerRepository timerRepository;
        [Inject] private SetNextCurrentLevelUseCase setNextCurrentLevelUseCase;
        [Inject] private UpdateCurrentLevelScoreUseCase updateCurrentLevelScoreUseCase;

        public void CompleteCurrentLevel()
        {
            timerRepository.StopTimer();
            updateCurrentLevelScoreUseCase.UpdateScore();
            var currentLevel = currentLevelRepository.GetCurrentLevel();
            setNextCurrentLevelUseCase.SetNextCurrentLevel();
            levelsRepository.SetLevelCompleted(currentLevel.ID);
            
            if (currentLevel.Reward > 0)
            {
                balanceRepository.Add(currentLevel.Reward, CurrencyType.Primary);
            }

            analytics.SendLevelEvent(new LevelPointer(currentLevel.ID), LevelEvent.Complete);
        }
    }
}