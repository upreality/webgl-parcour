using Data.LevelsData;
using UnityEngine;
using Zenject;

namespace Data
{
    [CreateAssetMenu(menuName = "Installers/DataInstaller")]
    public class DataInstaller: ScriptableObjectInstaller
    {
        [SerializeField] private DefaultLevelsDao levelsDao;
    
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<DefaultLevelsDao>().FromInstance(levelsDao).AsSingle();
        }
    }
}