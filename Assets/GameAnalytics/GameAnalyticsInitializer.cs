#if GAME_ANALYTICS
using Core.Auth.domain;
using GameAnalyticsSDK;
using UniRx;
using UnityEngine;
using Zenject;

namespace GAnalytics
{
    public class GameAnalyticsInitializer : MonoBehaviour
    {
        [Inject] private IAuthRepository authRepository;

        private void Awake() => authRepository
            .GetLoggedInFlow()
            .Where(loggedIn => loggedIn)
            .Subscribe(_ => SetupId())
            .AddTo(this);

        private void SetupId()
        {
            var userId = authRepository.LoginUserId;
            Debug.Log("Set up GameAnalytics user id: " + userId);
            GameAnalytics.SetCustomId(userId);
            GameAnalytics.Initialize();
        }
    }
}
#endif