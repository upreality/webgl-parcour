using Core.Auth.data;
using Core.Auth.domain;
using UnityEngine;
using Zenject;

namespace Core.Auth._di
{
    [CreateAssetMenu(menuName = "Installers/AuthInstaller")]
    public class AuthInstaller: ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IAuthRepository>().To<PlayfabAuthRepository>().AsSingle();
        }
    }
}