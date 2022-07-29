using System;
using System.Collections.Generic;
using Core.Auth.domain;
using Core.User.domain;
using PlayFab;
using PlayFab.ClientModels;
using UniRx;
using Zenject;

namespace Core.User.data
{
    public class PlayfabUserNameRepository : ICurrentUserNameRepository
    {
        [Inject] private IAuthRepository authRepository;
        [Inject] private UserNameLocalDataSource userNameLocalDataSource;

        public IObservable<string> GetUserNameFlow() => userNameLocalDataSource.GetUserNameFlow();

        public IObservable<bool> UpdateUserName(string newName) => authRepository
            .GetLoggedInFlow()
            .Where(loggedIn => loggedIn)
            .First()
            .Select(_ => UpdatePlayfabUserName(newName))
            .Switch();

        private IObservable<bool> UpdatePlayfabUserName(string newName) => Observable.Create(
            (IObserver<bool> observer) =>
            {
                var request = new UpdateUserDataRequest
                {
                    Data = new Dictionary<string, string>
                    {
                        [UserFields.UserName.ToString()] = newName
                    }
                };
                PlayFabClientAPI.UpdateUserData(
                    request,
                    success =>
                    {
                        userNameLocalDataSource.UpdateUserName(newName);
                        observer.OnNext(true);
                        observer.OnCompleted();
                    },
                    error =>
                    {
                        observer.OnNext(false);
                        observer.OnCompleted();
                    }
                );
                return Disposable.Create(() => { });
            }
        );
    }
}