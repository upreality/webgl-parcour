using System.Security.Cryptography;
using Features.BuildingsUpgrade.Interactions.Interfaces;
using Features.BuildingsUpgrade.Data;
using UnityEngine;

namespace Features.BuildingsUpgrade.Interactions
{
    public class MonoBuildingBuilder : MonoBehaviour
    {
        [SerializeField] private GameObject completedBuilding, destroyedBuilding;
        [SerializeField] private BoxCollider entranceZone;
        [SerializeField] private GameObject particles;
        [SerializeField] private BuildingUpgradeChannel upgradeChannel;
        [SerializeField] private UpgradeData data;
        
        private IBuildingView _buildingView;
        private bool _isInitialized;

        private void ChangeBuildingListener(UpgradeData upgradeData, int level)
        {
            if (data != upgradeData) return;
            if (_isInitialized)
            {
                print("feerwerk");
                var instance = Instantiate(particles, transform.position, Quaternion.identity);
                Destroy(instance, 10);
            }
            ChangeBuilding();
        }

        private void ChangeBuilding()
        {
            destroyedBuilding.SetActive(false);
            completedBuilding.SetActive(true);
            entranceZone.enabled = true;
        }

        private void Awake()
        {
            upgradeChannel.AddListener(ChangeBuildingListener);
        }

        private void Start()
        {
            if (data.IsHub)
            {
                upgradeChannel.Initialize();
            }

            _isInitialized = true;
        }
    }
}
