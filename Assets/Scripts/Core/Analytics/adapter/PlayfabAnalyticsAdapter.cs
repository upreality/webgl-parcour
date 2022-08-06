using Core.Analytics.ads;
using Core.Analytics.levels;
using Core.Analytics.screens;
using Core.Analytics.session.domain;
using Core.Analytics.settings;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

namespace Core.Analytics.adapter
{
    public class PlayfabAnalyticsAdapter : AnalyticsAdapter
    {
        public override void SendAdEvent(AdAction action, AdType type, AdProvider provider, IAdPlacement placement)
        {
            if(action!=AdAction.Show)
                return;

            PlayFabClientAPI.ReportAdActivity(
                new ReportAdActivityRequest
                {
                    Activity = AdActivity.Start,
                    PlacementId = placement.GetName()
                },
                _ => { },
                _ => { }
            );
        }

        public override void SendSettingsEvent(SettingType type, string val)
        {
            PlayFabClientAPI.
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