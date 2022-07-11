using Doozy.Engine;
using UniRx;
using UnityEngine;
using Zenject;

namespace Ads.presentation.InterstitialAdNavigator
{
    public class ShowInterstitialBridge: MonoBehaviour
    {
        [Inject(Id = IInterstitialAdNavigator.DefaultInstance)] private IInterstitialAdNavigator navigator;
        [SerializeField] private string onShownEvent;
        [SerializeField] private string onFailedEvent;

        public void TryShow()
        {
            navigator.ShowAd().Subscribe(
                res =>
                {
                    var message = res.IsSuccess ? onShownEvent : onFailedEvent;
                    GameEventMessage.SendEvent(message);
                },
                e => GameEventMessage.SendEvent(onFailedEvent)
            ).AddTo(this);
        }
    }
}