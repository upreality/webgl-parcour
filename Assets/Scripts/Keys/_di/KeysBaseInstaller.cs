using Gameplay.Keys.domain;
using Keys.data;
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
            Container.Bind<IKeysRepository>().FromInstance(keysRepository).AsSingle();
        }
    }
}