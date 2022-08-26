﻿using Core.Analytics.levels;
using Features.Levels.domain.repositories;
using Zenject;

namespace Features.Levels.domain
{
    public class LevelFailedAnalyticsEventUseCase
    {
        [Inject] private ICurrentLevelRepository currentLevelRepository;
        [Inject] private ILevelsAnalyticsRepository analyticsRepository;

        public void Send()
        {
            var levelId = currentLevelRepository.GetCurrentLevel().ID;
            analyticsRepository.SendLevelEvent(levelId, LevelEvent.Fail);
        }
    }
}