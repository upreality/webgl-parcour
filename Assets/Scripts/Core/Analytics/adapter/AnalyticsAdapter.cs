using Core.Analytics.ads;
using Core.Analytics.levels;
using Core.Analytics.screens;
using Core.Analytics.session.domain;
using Core.Analytics.settings;

namespace Core.Analytics.adapter
{
    public abstract class AnalyticsAdapter
    {
        public abstract void SendAdEvent(AdAction action, AdType type, AdProvider provider, IAdPlacement placement);
        public abstract void SendSettingsEvent(SettingType type, string val);
        public abstract void SendScreenEvent(string screenName, ScreenAction action);
        public abstract void SendLevelEvent(LevelPointer levelPointer, LevelEvent levelEvent);
        public abstract void SendSessionEvent(SessionEvent sessionEvent, LevelPointer currentLevelPointer);
        public abstract void SendErrorEvent(string error);
        public abstract void SetPlayerId(string id);
        public abstract void InitializeWithoutPlayerId();
        public abstract void SendFirstOpenEvent();
        public abstract void SendPurchasedEvent(long purchaseId);
        public abstract void SendBalanceAddedEvent(int amount);
    }
}