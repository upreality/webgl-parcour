using Core.User.data;
using Core.User.domain;
using Core.User.presentation;
using UnityEngine;
using Zenject;

namespace Core.User._di
{
    public class UserInstaller : MonoInstaller
    {
        [SerializeField] private EditUserNameNavigator editUserNameNavigator;

        public override void InstallBindings()
        {
            Container.Bind<UserNameLocalDataSource>().ToSelf().AsSingle();
            Container.Bind<ICurrentUserNameRepository>().To<PlayfabUserNameRepository>().AsSingle();
            Container.Bind<ValidateUserNameUseCase>().ToSelf().AsSingle();
            Container.Bind<EditUserNameNavigator>().FromInstance(editUserNameNavigator).AsSingle();
        }
    }
}