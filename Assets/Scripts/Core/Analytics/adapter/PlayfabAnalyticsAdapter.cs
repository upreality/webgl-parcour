using System.Collections.Generic;
using Core.Analytics.ads;
using Core.Analytics.levels;
using Core.Analytics.screens;
using Core.Analytics.session.domain;
using Core.Analytics.settings;
using PlayFab;
using PlayFab.ClientModels;
using PlayFab.EventsModels;
using UnityEngine;

namespace Core.Analytics.adapter
{
    public class PlayfabAnalyticsAdapter : AnalyticsAdapter
    {
        public override void SendAdEvent(AdAction action, AdType type, AdProvider provider, IAdPlacement placement)
        {
            if (action != AdAction.Show)
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

        public override void SendSettingsEvent(SettingType type, bool val)
        {
            PlayFabClientAPI.UpdatePlayerStatistics(
                new UpdatePlayerStatisticsRequest
                {
                    Statistics = new List<StatisticUpdate>()
                    {
                        new()
                        {
                            StatisticName = "Settings_" + type,
                            Value = val ? 1 : 0
                        }
                    }
                },
                _ => { },
                _ => { }
            );
            PlayFabEventsAPI.WriteEvents(
                new WriteEventsRequest
                {
                    Events = new List<EventContents>()
                    {
                        new()
                        {
                            EventNamespace = "custom.Settings",
                            Name = "SetSettings",
                            Payload = val
                        }
                    }
                },
                _ => { },
                _ => { }
            );
        }

        public override void SendScreenEvent(string screenName, ScreenAction action)
        {
            PlayFabEventsAPI.WriteEvents(
                new WriteEventsRequest
                {
                    Events = new List<EventContents>()
                    {
                        new()
                        {
                            EventNamespace = "custom.Navigation",
                            Name = "ScreenEvent",
                            Payload = screenName + ", " + action
                        }
                    }
                },
                _ => { },
                _ => { }
            );
        }

        public override void SendLevelEvent(LevelPointer levelPointer, LevelEvent levelEvent)
        {
            Debug.Log("Analytics SendLevelEvent" );
            PlayFabEventsAPI.WriteEvents(
                new WriteEventsRequest
                {
                    Events = new List<EventContents>()
                    {
                        new()
                        {
                            EventNamespace = "custom.Levels",
                            Name = levelEvent.ToString(),
                            Payload = "level: " + levelPointer.LevelId
                        }
                    }
                },
                _ =>
                {
                    Debug.Log("Analytics SendLevelEvent res" );
                },
                _ =>
                {
                    Debug.Log("Analytics SendLevelEvent err" );
                }
            );
        }

        public override void SendSessionEvent(SessionEvent sessionEvent, LevelPointer currentLevelPointer)
        {
            //Skip
            //TODO: remove if unused
        }

        public override void SendErrorEvent(string error)
        {
            //Skip
            //TODO: remove if unused
        }

        public override void SetPlayerId(string id)
        {
            //Skip
            //TODO: remove if unused
        }

        public override void InitializeWithoutPlayerId()
        {
            //Skip
            //TODO: remove if unused
        }

        public override void SendFirstOpenEvent()
        {
            //TODO: remove if unused
        }

        public override void SendPurchasedEvent(long purchaseId)
        {
            PlayFabEventsAPI.WriteEvents(
                new WriteEventsRequest
                {
                    Events = new List<EventContents>()
                    {
                        new()
                        {
                            EventNamespace = "custom.Economy",
                            Name = "Purchase",
                            Payload = "purchaseId: " + purchaseId
                        }
                    }
                },
                _ => { },
                _ => { }
            );
        }

        public override void SendBalanceAddedEvent(int amount)
        {
            //TODO
        }
    }
}