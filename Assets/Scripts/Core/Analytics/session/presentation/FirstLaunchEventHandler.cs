using Core.Analytics.adapter;
using Core.Analytics.session.domain;
using UnityEngine;
using Zenject;

namespace Core.Analytics.session.presentation
{
    public class FirstLaunchEventHandler : MonoBehaviour
    {
        [Inject] private IFirstOpenEventSentRepository firstOpenEventSentRepository;
        [Inject] private AnalyticsAdapter analytics;
        
        private void Start()
        {
            if(!firstOpenEventSentRepository.IsFirstOpen()) return;
            analytics.SendFirstOpenEvent();
            firstOpenEventSentRepository.SetFirstOpenAppeared();
        }
    }
}
