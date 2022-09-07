using Core.Analytics.adapter;
using Doozy.Engine.UI;
using UnityEngine;
using Zenject;

namespace Core.Analytics.screens
{
    [RequireComponent(typeof(UIView))]
    public class ScreenStateAnalyticsHandler : MonoBehaviour
    {
        private UIView target;
        [Inject] private AnalyticsAdapter analytics;
        [SerializeField] private string screenName;

        private void Start()
        {
            target = GetComponent<UIView>();
            target.ShowBehavior.OnFinished.Event.AddListener(() => SendEvent(ScreenAction.Open));
            target.HideBehavior.OnFinished.Event.AddListener(() => SendEvent(ScreenAction.Close));
        }

        private void SendEvent(ScreenAction action) => analytics.SendScreenEvent(screenName, action);
    }
}