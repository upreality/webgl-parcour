﻿using System.Collections.Generic;
using Features.Purchases.domain.repositories;
using PlayFab;
using PlayFab.EventsModels;

namespace Features.Purchases.data
{
    public class PlayfabPurchaseAnalyticsRepository : IPurchaseAnalyticsRepository
    {
        public void SendPurchasedEvent(long purchaseId)
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
    }
}