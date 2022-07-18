using Core.Analytics.adapter;
using Core.Analytics.levels;
using Features.Levels.domain.repositories;
using UnityEngine;
using Zenject;

namespace Features.Levels.presentation.analytics
{
    public class LevelCompletedAnalyticsEvent : MonoBehaviour
    {
        [Inject] private AnalyticsAdapter analytics;
        [Inject] private ICurrentLevelRepository currentLevelRepository;

        public void Send()
        {
            var levelId = currentLevelRepository.GetCurrentLevel().ID;
            analytics.SendLevelEvent(new LevelPointer(levelId), LevelEvent.Complete);
        }
    }
}