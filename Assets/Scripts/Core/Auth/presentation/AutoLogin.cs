using Core.Auth.domain;
using UniRx;
using UnityEngine;
using Zenject;

namespace Core.Auth.presentation
{
    public class AutoLogin : MonoBehaviour
    {
        [Inject] private IAuthRepository authRepository;

        private void Start() => authRepository
            .GetLoggedInFlow()
            .Where(loggedIn => !loggedIn)
            .Subscribe(_ => authRepository.Login(() => { }, () => { }))
            .AddTo(this);
    }
}