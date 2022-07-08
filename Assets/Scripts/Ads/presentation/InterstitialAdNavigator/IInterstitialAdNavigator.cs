using System;

namespace Ads.presentation.InterstitialAdNavigator
{
    public interface IInterstitialAdNavigator
    {
        IObservable<ShowInterstitialResult> ShowAd();

        const string DeathInterstitialAdNavigatorId = "DeathInterstitialAdNavigatorId";
        const string LevelLoadedInterstitialAdNavigatorId = "LevelLoadedInterstitialAdNavigator";
    }

    public class ShowInterstitialResult
    {
        public bool isSuccess = false;
        public string error;

        public static ShowInterstitialResult Success = new ShowInterstitialResult(true);

        public ShowInterstitialResult(bool isSuccess, string error = "")
        {
            this.isSuccess = isSuccess;
            this.error = error;
        }
    }
}