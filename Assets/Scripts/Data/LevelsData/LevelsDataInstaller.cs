using UnityEngine;
using Zenject;

namespace Data.LevelsData
{
    [CreateAssetMenu(menuName = "Installers/LevelsDataInstaller")]
    public class LevelsDataInstaller: ScriptableObjectInstaller
    {
        [SerializeField] private DefaultLevelsDao levelsDao;
    
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<DefaultLevelsDao>().FromInstance(levelsDao).AsSingle();
        }
    }
}