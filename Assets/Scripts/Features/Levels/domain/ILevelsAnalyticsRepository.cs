using Core.Analytics.levels;

namespace Features.Levels.domain
{
    public interface ILevelsAnalyticsRepository
    {
        void SendLevelEvent(long levelId, LevelEvent levelEvent);
    }
}