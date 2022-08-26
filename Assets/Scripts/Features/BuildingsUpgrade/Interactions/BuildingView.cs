using System;
using Features.BuildingsUpgrade.Settings.Interfaces;
using Features.BuildingsUpgrade.Data;
using Features.BuildingsUpgrade.Interactions.Interfaces;
using Object = UnityEngine.Object;

namespace Features.BuildingsUpgrade.Interactions
{
    public class BuildingView : IBuildingView
    {
        public BuildingView(IUpgradeSettings upgradeSettings)
        {
            _upgradeSettings = upgradeSettings;
            _upgradeSettings.UpgradeChannel.AddListener(OpenShop);
            _upgradeSettings.CloseButton.onClick.AddListener(() => OpenShop(false));
        }

        public event Action<UpgradeData> OnSkillsOpen = _ => { };

        private readonly IUpgradeSettings _upgradeSettings;

        private void OpenShop(bool value)
        {
            _upgradeSettings.SecondPage.gameObject.SetActive(false);
            _upgradeSettings.FirstPage.gameObject.SetActive(true);
            _upgradeSettings.ShopPanel.gameObject.SetActive(value);
        }

        public void Initialize(UpgradeRepository upgradeRepository)
        {
            var upgradeList = upgradeRepository.UpgradeList;
            var buttonPrefab = _upgradeSettings.ButtonPrefab;
            var buttonHandler = _upgradeSettings.ButtonsHandler;

            upgradeList.ForEach(data => { Object.Instantiate(buttonPrefab, buttonHandler).Initialize(data, this); });
        }

        public void UpdateSkillLevel(int activeCount, int count)
        {
            _upgradeSettings.SecondPage.SetButtons(activeCount, count);
        }
        
        public void OpenSkillPage(UpgradeData upgradeData)
        {
            OnSkillsOpen.Invoke(upgradeData);
            var skillPage = _upgradeSettings.SecondPage;
            skillPage.gameObject.SetActive(true);
            skillPage.Initialize(upgradeData);
            
            _upgradeSettings.FirstPage.gameObject.SetActive(false);
        }
    }
}