using Core.Analytics.levels;
using Features.Levels.domain;
using Zenject;

namespace Features.Levels.presentation.ui
{
    public class LevelItemControllerAnalyticsDecorator : LevelItem.ILevelItemController
    {
        private readonly LevelItem.ILevelItemController target;
        private readonly ILevelsAnalyticsRepository analyticsRepository;

        [Inject]
        public LevelItemControllerAnalyticsDecorator(
            LevelItem.ILevelItemController decorationTarget,
            ILevelsAnalyticsRepository analytics
        )
        {
            target = decorationTarget;
            analyticsRepository = analytics;
        }

        public void OnItemClick(long levelId)
        {
            analyticsRepository.SendLevelEvent(levelId, LevelEvent.Load);
            target.OnItemClick(levelId);
        }
    }
}