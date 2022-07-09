using Ads.data;
using Ads.presentation.InterstitialAdNavigator;
using Ads.presentation.InterstitialAdNavigator.core;
using Ads.presentation.InterstitialAdNavigator.decorators;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Ads._di
{
    public class AdsInstaller : MonoInstaller
    {
        [SerializeField] private InterstitialAdNavigatorLockLookDecorator interstitialAdNavigatorLockLookDecorator;
        [SerializeField] private InterstitialAdNavigatorMuteAudioDecorator muteAudioInterstitialAdNavigatorDecorator;

        public override void InstallBindings()
        {
            Container
                .Bind<IInterstitialAdNavigator>()
#if YANDEX_SDK
                .To<YandexInterstitialAdNavigator>()
                .AsSingle()
                .WhenInjectedInto<YandexInterstitialNavigatorHitsDecorator>();
                
            Container
                .Bind<IInterstitialAdNavigator>()
                .To<YandexInterstitialNavigatorHitsDecorator>()
#elif VK_SDK
                .To<VKInterstitialAdNavigator>()
#elif POKI_SDK
                .To<PokiInterstitialAdNavigator>()
#elif CRAZY_SDK
                .To<CrazyInterstitialAdNavigator>()
#else
                .To<DebugLogInterstitialAdNavigator>()
#endif
                .AsSingle()
                .WhenInjectedInto<InterstitialAdNavigatorAnalyticsDecorator>();

            Container
                .Bind<IInterstitialAdNavigator>()
                .To<InterstitialAdNavigatorAnalyticsDecorator>()
                .FromNew()
                .AsSingle()
                .WhenInjectedInto<InterstitialAdNavigatorLockLookDecorator>();

            Container
                .Bind<IInterstitialAdNavigator>()
                .To<InterstitialAdNavigatorLockLookDecorator>()
                .FromInstance(interstitialAdNavigatorLockLookDecorator)
                .AsSingle()
                .WhenInjectedInto<InterstitialAdNavigatorMuteAudioDecorator>();

            Container
                .Bind<IInterstitialAdNavigator>()
                .To<InterstitialAdNavigatorMuteAudioDecorator>()
                .FromInstance(muteAudioInterstitialAdNavigatorDecorator)
                .AsSingle()
                .WhenInjectedInto<InterstitialAdNavigatorCounterDecorator>();

            Container
                .Bind<IInterstitialAdNavigator>()
                .To<InterstitialAdNavigatorMuteAudioDecorator>();
        }
    }
}