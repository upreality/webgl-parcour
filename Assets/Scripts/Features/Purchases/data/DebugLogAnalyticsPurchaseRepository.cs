﻿using Features.Purchases.domain.repositories;
using UnityEngine;

namespace Features.Purchases.data
{
    public class DebugLogAnalyticsPurchaseRepository: IPurchaseAnalyticsRepository
    {
        public void SendPurchasedEvent(long purchaseId)
        {
            Debug.Log("Debug purchased analytics event: " + purchaseId);
        }
    }
}