using System.Collections.Generic;
using Core.Analytics.levels;
using Features.Levels.domain;
using PlayFab;
using PlayFab.EventsModels;
using UnityEngine;

namespace Features.Levels.data
{
    public class DebugLogLevelAnalyticsRepository: ILevelsAnalyticsRepository
    {
        public void SendLevelEvent(long levelId, LevelEvent levelEvent)
        {
            Debug.Log("SendLevelEvent: " + levelId + ' ' + levelEvent);
        }
    }
}