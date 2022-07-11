using Keys.data;
using Keys.domain;
using Keys.presentation;
using UnityEngine;
using Zenject;

namespace Keys._di
{
    [CreateAssetMenu(fileName = "KeysBaseInstaller", menuName = "Installers/KeysBaseInstaller")]
    public class KeysBaseInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            var keysRepository = FindObjectOfType<KeysSceneRepository>();
            var keyCollectNavigator = FindObjectOfType<KeyCollectNavigator>();
            Container.Bind<IKeysRepository>().FromInstance(keysRepository).AsSingle();
            Container.BindInstance(keyCollectNavigator).AsSingle();
        }
    }
}