#if GAME_ANALYTICS
using System.Collections.Generic;
using Core.Analytics.ads;
using Core.Analytics.levels;
using Core.Analytics.screens;
using Core.Analytics.settings;
using Core.SDK.SDKType;
using GameAnalyticsSDK;
using UnityEngine;

namespace Core.Analytics.adapter
{
    public class GameAnalyticsAdapter : AnalyticsAdapter
    {
        private static string defaultPostfix = "Undefined";

        public override void SendAdEvent(AdAction action, AdType type, AdProvider provider, IAdPlacement placement)
        {
            Debug.Log("SendAdEvent: " + action + ' ' + type);
            var gAAction = action switch
            {
                AdAction.Request => GAAdAction.Request,
                AdAction.Show => GAAdAction.Show,
                AdAction.Failure => GAAdAction.FailedShow,
                _ => GAAdAction.Undefined
            };
            var gAType = type switch
            {
                AdType.Rewarded => GAAdType.RewardedVideo,
                AdType.Interstitial => GAAdType.Interstitial,
                _ => GAAdType.Undefined
            };
            GameAnalytics.NewAdEvent(gAAction, gAType, provider.ToString(), placement.GetName());
        }

        public override void SetPlatform(SDKProvider.SDKType platform)
        {
            GameAnalytics.SetCustomDimension01(platform.ToString());
        }

        public override void SendSettingsEvent(SettingType type, bool state)
        {
            Debug.Log("SendSettingsEvent: " + type + ' ' + state);
            var eventName = "Setting_" + type switch
            {
                SettingType.SoundToggle => "Sound",
                _ => defaultPostfix
            };
            var param = new Dictionary<string, object> { { "value", state } };
            GameAnalytics.NewDesignEvent(eventName, param);
        }

        public override void SendScreenEvent(string screenName, ScreenAction action)
        {
            Debug.Log("SendScreenEvent: " + screenName + ' ' + action);
            var eventName = "Screen_" + action switch
            {
                ScreenAction.Open => "Open",
                ScreenAction.Close => "Close",
                _ => defaultPostfix
            };
            var param = new Dictionary<string, object> { { "screenName", screenName } };
            GameAnalytics.NewDesignEvent(eventName, param);
        }

        public override void SendLevelEvent(LevelPointer levelPointer, LevelEvent levelEvent)
        {
            Debug.Log("SendLevelEvent: " + levelPointer.LevelId + ' ' + levelEvent);
            if (levelEvent == LevelEvent.Load)
            {
                SendLoadLevelEvent(levelPointer);
                return;
            }

            var gAProgressionStatus = levelEvent switch
            {
                LevelEvent.Start => GAProgressionStatus.Start,
                LevelEvent.Fail => GAProgressionStatus.Fail,
                LevelEvent.Complete => GAProgressionStatus.Complete,
                _ => GAProgressionStatus.Undefined
            };
            ;
            GameAnalytics.NewProgressionEvent(gAProgressionStatus, "Level_" + levelPointer.LevelId);
        }

        private static void SendLoadLevelEvent(LevelPointer levelPointer)
        {
            var param = new Dictionary<string, object> { { "levelId", levelPointer.LevelId } };
            GameAnalytics.NewDesignEvent("ManualLoadLevel", param);
        }
    }
}
#endif