using System;
using System.Collections.Generic;
using Core.User.domain;
using UniRx;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Core.User.presentation
{
    public class UserNameSetup: MonoBehaviour
    {
        [SerializeField] private List<string> defaultUserNames = new();
        [Inject] private ICurrentUserNameRepository currentUserNameRepository;

        private void Start() => currentUserNameRepository
            .GetUserNameFlow()
            .Where(string.IsNullOrWhiteSpace)
            .Subscribe(_ => SetRandomUserName())
            .AddTo(this);

        private void SetRandomUserName()
        {
            if(defaultUserNames.Count==0)
                return;
            
            var nameIndex = Random.Range(0, defaultUserNames.Count);
            currentUserNameRepository
                .UpdateUserName(defaultUserNames[nameIndex])
                .Subscribe()
                .AddTo(this);
        }
    }
}