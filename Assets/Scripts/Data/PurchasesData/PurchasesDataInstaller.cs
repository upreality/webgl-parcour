using UnityEngine;
using Zenject;

namespace Data.PurchasesData
{
    [CreateAssetMenu(menuName = "Installers/PurchasesDataInstaller")]
    public class PurchasesDataInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private DefaultPurchaseEntitiesDao defaultPurchaseEntitiesDao;

        public override void InstallBindings()
        {
            Container.Bind<IPurchaseEntitiesDao>().FromInstance(defaultPurchaseEntitiesDao).AsSingle();
        }
    }
}