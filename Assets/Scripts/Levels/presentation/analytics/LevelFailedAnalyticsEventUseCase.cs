using Analytics.adapter;
using Analytics.levels;
using Levels.domain.repositories;
using Zenject;

namespace Levels.presentation.analytics
{
    public class LevelFailedAnalyticsEventUseCase
    {
        [Inject] private ICurrentLevelRepository currentLevelRepository;
        [Inject] private AnalyticsAdapter analytics;

        public void Send()
        {
            var levelId = currentLevelRepository.GetCurrentLevel().ID;
            var pointer = new LevelPointer(levelId);
            analytics.SendLevelEvent(pointer, LevelEvent.Fail);
        }
    }
}