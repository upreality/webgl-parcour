using System;
using UniRx;
using UnityEngine;
using Zenject;

namespace Core.Ads.presentation.InterstitialAdNavigator.decorators
{
    public class InterstitialAdNavigatorLockLookDecorator : MonoBehaviour, IInterstitialAdNavigator
    {
        [SerializeField] private GameObject menuUI;
        [Inject] private IInterstitialAdNavigator Target;

        public IObservable<ShowInterstitialResult> ShowAd()
        {
            SetLockedState(true);
            return Target
                .ShowAd()
                .Do(_ => SetLockedState(false))
                .DoOnError(_ => SetLockedState(false));
        }

        private void SetLockedState(bool locked)
        {
            Debug.Log("SetLockedState: " + locked);
            if (locked)
            {
                //TODO: reimplement look input controlling via GameStateNavigator
                // look.SetEnabledState(false);
            }

            if (!locked && !menuUI.activeSelf)
            {
                //TODO: reimplement look input controlling via GameStateNavigator
                // look.SetEnabledState(true);
            }
            
            Time.timeScale = locked ? 0f : 1f;
        }
    }
}