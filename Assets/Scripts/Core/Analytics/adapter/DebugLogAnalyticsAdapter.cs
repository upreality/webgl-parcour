using Core.Analytics.ads;
using Core.Analytics.levels;
using Core.Analytics.screens;
using Core.Analytics.session.domain;
using Core.Analytics.settings;
using UnityEngine;

namespace Core.Analytics.adapter
{
    public class DebugLogAnalyticsAdapter : AnalyticsAdapter
    {
        private readonly bool loggingEnabled = false;

        public DebugLogAnalyticsAdapter(bool loggingEnabled)
        {
            this.loggingEnabled = loggingEnabled;
        }

        public override void SendAdEvent(AdAction action, AdType type, AdProvider provider, IAdPlacement placement)
        {
            Log(" SendAdEvent: " + action + ' ' + type);
        }

        public override void SendSettingsEvent(SettingType type, bool val)
        {
            Log("SendSettingsEvent: " + type + ' ' + val);
        }

        public override void SendScreenEvent(string screenName, ScreenAction action)
        {
            Log("SendScreenEvent: " + screenName + ' ' + action);
        }

        public override void SendLevelEvent(LevelPointer levelPointer, LevelEvent levelEvent)
        {
            Log("SendLevelEvent: " + levelPointer.LevelId + ' ' + levelEvent);
        }

        public override void SendSessionEvent(SessionEvent sessionEvent, LevelPointer currentLevelPointer)
        {
            Log("SendSessionEvent: " + sessionEvent);
        }

        public override void SendErrorEvent(string error)
        {
            Log("SendErrorEvent: " + error);
        }

        public override void SetPlayerId(string id)
        {
            Log("Set player id: " + id);
        }

        public override void InitializeWithoutPlayerId()
        {
            Log("Initialize Analytics Without PlayerId");
        }

        public override void SendFirstOpenEvent()
        {
            Log("First Open");
        }

        public override void SendPurchasedEvent(long purchaseId)
        {
            Debug.Log("SendPurchasedEvent");
        }

        public override void SendBalanceAddedEvent(int amount)
        {
            Debug.Log("SendBalanceAddedEvent");
        }

        private void Log(string text)
        {
            if (!loggingEnabled) return;
            Debug.Log("Debug Analytics Event: " + text);
        }
    }
}