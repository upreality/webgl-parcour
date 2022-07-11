using System;

namespace Ads.presentation.InterstitialAdNavigator
{
    public interface IInterstitialAdNavigator
    {
        IObservable<ShowInterstitialResult> ShowAd();

        public const string DefaultInstance = "DefInstance";
    }

    public class ShowInterstitialResult
    {
        public bool IsSuccess = false;
        public string Error;

        public static ShowInterstitialResult Success = new ShowInterstitialResult(true);

        public ShowInterstitialResult(bool isSuccess, string error = "")
        {
            this.IsSuccess = isSuccess;
            this.Error = error;
        }
    }
}