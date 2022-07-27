using System;
using Core.Analytics.adapter;
using Core.Analytics.ads;
using Core.Analytics.ads.placement;
using UniRx;
using Zenject;

namespace Core.Ads.presentation.InterstitialAdNavigator.decorators
{
    public class InterstitialAdNavigatorAnalyticsDecorator : IInterstitialAdNavigator
    {
        [Inject] private IInterstitialAdNavigator target;
        [Inject] private AnalyticsAdapter analytics;

        private IAdPlacement placement = new SimpleAdPlacement("undefined");
        private AdProvider provider = AdProviderProvider.CurrentProvider;

        public IObservable<ShowInterstitialResult> ShowAd()
        {
            SendEvent(AdAction.Request);
            return target.ShowAd().Do(HandleShowResult);
        }

        private void HandleShowResult(ShowInterstitialResult result)
        {
            if (!result.IsSuccess)
                OnFailed(result.Error);
            else
                OnShown();
        }

        private void OnShown() => SendEvent(AdAction.Show);

        private void OnFailed(string error) => SendEvent(AdAction.Failure);

        private void SendEvent(AdAction action)
        {
            analytics.SendAdEvent(action, AdType.Interstitial, provider, placement);
        }
    }
}