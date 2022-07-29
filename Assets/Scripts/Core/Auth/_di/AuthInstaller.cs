using Core.Auth.data;
using Core.Auth.domain;
using Zenject;

namespace Core.Auth._di
{
    public class AuthInstaller: ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IAuthRepository>().To<PlayfabAuthRepository>().AsSingle();
        }
    }
}