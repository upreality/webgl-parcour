using Core.Analytics.adapter;
using Core.SDK.PlayerData.domain;
using UniRx;
using UnityEngine;
using Zenject;

namespace Core.Analytics
{
    public class SetAnalyticsPlayerId : MonoBehaviour
    {
        [Inject] private AnalyticsAdapter analytics;
        [Inject] private IPlayerIdRepository playerIdRepository;

        private void Awake()
        {
            Debug.Log("GetPlayerIdAvailable: " + playerIdRepository.GetPlayerIdAvailable());
            if (!playerIdRepository.GetPlayerIdAvailable())
            {
                analytics.InitializeWithoutPlayerId();
                return;
            }

            SetupId();
        }

        private void SetupId() => playerIdRepository
            .InitializeWithPlayerId()
            .Subscribe(id => analytics.SetPlayerId(id))
            .AddTo(this);
    }
}