using System;
using Core.Analytics.adapter;
using Core.Analytics.levels;
using Features.Balance.domain;
using Features.Balance.domain.repositories;
using Features.GlobalScore.domain;
using Features.Levels.domain;
using Features.Levels.domain.repositories;
using Features.LevelScore.domain;
using UniRx;
using Zenject;

namespace Features.LevelsProgression.domain
{
    public class CompleteCurrentLevelUseCase
    {
        [Inject] private ILevelsAnalyticsRepository analyticsRepository;
        [Inject] private ILevelCompletedStateRepository levelsRepository;
        [Inject] private ICurrentLevelRepository currentLevelRepository;
        [Inject] private IBalanceRepository balanceRepository;
        [Inject] private SetNextCurrentLevelUseCase setNextCurrentLevelUseCase;
        [Inject] private UpdateCurrentLevelScoreUseCase updateCurrentLevelScoreUseCase;
        [Inject] private UpdateGlobalScoreUseCase updateGlobalScoreUseCase;

        public IObservable<bool> CompleteCurrentLevel()
        {
            var currentLevel = currentLevelRepository.GetCurrentLevel();
            levelsRepository.SetLevelCompleted(currentLevel.ID);
            setNextCurrentLevelUseCase.SetNextCurrentLevel();
            if (currentLevel.Reward > 0) balanceRepository.Add(currentLevel.Reward, CurrencyType.Primary);
            analyticsRepository.SendLevelEvent(currentLevel.ID, LevelEvent.Complete);
            return updateCurrentLevelScoreUseCase.UpdateScore().Select(levelRes =>
                updateGlobalScoreUseCase.UpdateGlobalScore().Select(globalRes => levelRes && globalRes)
            ).Switch();
        }
    }
}