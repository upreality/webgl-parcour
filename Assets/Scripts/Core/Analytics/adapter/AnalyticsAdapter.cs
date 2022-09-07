﻿using Core.Analytics.ads;
using Core.Analytics.screens;
using Core.Analytics.settings;
using Core.SDK.SDKType;

namespace Core.Analytics.adapter
{
    public abstract class AnalyticsAdapter
    {
        public abstract void SendAdEvent(AdAction action, AdType type, AdProvider provider, IAdPlacement placement);
        public abstract void SetPlatform(SDKProvider.SDKType platform);
        public abstract void SendSettingsEvent(SettingType type, bool state);
        public abstract void SendScreenEvent(string screenName, ScreenAction action);
    }
}