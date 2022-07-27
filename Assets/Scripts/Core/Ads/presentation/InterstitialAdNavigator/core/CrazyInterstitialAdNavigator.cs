using System;
using CrazyGames;
using UniRx;
#if CRAZY_SDK
#endif

namespace Core.Ads.presentation.InterstitialAdNavigator.core
{
    public class CrazyInterstitialAdNavigator : IInterstitialAdNavigator
    {
        public IObservable<ShowInterstitialResult> ShowAd()
        {
#if CRAZY_SDK
            return Observable.Create((IObserver<ShowInterstitialResult> observer) =>
                {
                    CrazyAds.Instance.beginAdBreak(
                        () =>
                        {
                            observer.OnNext(ShowInterstitialResult.Success);
                            observer.OnCompleted();
                        },
                        () =>
                        {
                            observer.OnNext(new ShowInterstitialResult(false));
                            observer.OnCompleted();
                        }
                    );
                    return Disposable.Create(() => { });
                }
            );
#endif
            return Observable.Return(ShowInterstitialResult.Success);
        }
    }
}