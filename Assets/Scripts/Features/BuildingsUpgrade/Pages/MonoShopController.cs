using Features.BuildingsUpgrade.Interactions.Interfaces;
using UnityEngine;
using Zenject;

namespace Features.BuildingsUpgrade.Pages
{
    public class MonoShopController : MonoBehaviour
    {
        [Inject]
        private void Construct(IBuildingView buildingView)
        {
            _buildingView = buildingView;
        }

        private IBuildingView _buildingView;
    
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _buildingView.OpenShop(false);
            }
        }
    }
}
