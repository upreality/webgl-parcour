using UnityEngine;
using Zenject;

namespace Data.BuildingsData
{
    [CreateAssetMenu(menuName = "Installers/BuildingsDataInstaller")]
    public class BuildingsDataInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private DefaultBuildingsDao dao;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<DefaultBuildingsDao>().FromInstance(dao);
        }
    }
}