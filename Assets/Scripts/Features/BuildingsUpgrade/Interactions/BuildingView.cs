using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Features.Balance.domain;
using Features.BuildingsUpgrade.Settings.Interfaces;
using Features.BuildingsUpgrade.Data;
using Features.BuildingsUpgrade.Interactions.Interfaces;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Features.BuildingsUpgrade.Interactions
{
    public class BuildingView : IBuildingView
    {
        public BuildingView(IUpgradeSettings upgradeSettings, DecreaseBalanceUseCase balanceUseCase)
        {
            _upgradeSettings = upgradeSettings;
            BalanceUseCase = balanceUseCase;
            _upgradeSettings.InteractionChannel.AddListener(Interact);
            _upgradeSettings.UpgradeChannel.OnInitialized += InitializeBuildings;
            _upgradeSettings.CloseButton.onClick.AddListener(() => OpenShop(false));
        }

        private event Action OnSwitchButton = () => { };
        public event Action<UpgradeData> OnSkillsOpen;
        public event Action<UpgradeData, int> OnBuyUpgrade = (x, y) => { };

        private readonly IUpgradeSettings _upgradeSettings;
        private Dictionary<UpgradeData, int> _upgradesDictionary;
        private readonly List<MonoBuildingButton> _buildingButtons = new();

        private void Interact(UpgradeData upgradeData)
        {
            if (upgradeData.IsHub) OpenShop(true);
            else
            {
                _upgradeSettings.ShopPanel.gameObject.SetActive(true);
                OpenSkillPage(upgradeData);
            }
        }

        public void OpenShop(bool value)
        {
            _upgradeSettings.SecondPage.gameObject.SetActive(false);
            _upgradeSettings.FirstPage.gameObject.SetActive(true);
            _upgradeSettings.ShopPanel.gameObject.SetActive(value);
        }

        public void Initialize(Dictionary<UpgradeData, int> upgradesDictionary)
        {
            _upgradesDictionary = upgradesDictionary;
            var buttonPrefab = _upgradeSettings.ButtonPrefab;
            var buttonHandler = _upgradeSettings.ButtonsHandler;

            foreach (var data in _upgradesDictionary)
            {
                _buildingButtons.Add(Object.Instantiate(buttonPrefab, buttonHandler));
            }

            UpdateButtons();
        }

        private void InitializeBuildings()
        {
            foreach (var data in _upgradesDictionary.Where(data => data.Value >= 1))
            {
                _upgradeSettings.UpgradeChannel.Fire(data.Key, 1);
            }
            
            _upgradeSettings.UpgradeChannel.OnInitialized -= InitializeBuildings;
        }

        public void UpdateView(UpgradeData upgradeData, int level)
        {
            _upgradesDictionary[upgradeData] = level;
            UpdateButtons();
        }

        private void UpdateButtons()
        {
            var id = 0;
            foreach (var data in _upgradesDictionary)
            {
                _buildingButtons[id].Initialize(data, this);
                id += 1;
            }
        }

        public void UpdateSkillLevel(int activeCount, int count)
        {
            _upgradeSettings.SecondPage.SetButtons(activeCount, count);
        }

        public void OpenSkillPage(UpgradeData upgradeData)
        {
            var skillPage = _upgradeSettings.SecondPage;
            skillPage.gameObject.SetActive(true);
            skillPage.Initialize(upgradeData, this);
            OnSkillsOpen.Invoke(upgradeData);

            _upgradeSettings.FirstPage.gameObject.SetActive(false);
        }

        public void DisplayInfo(UpgradeData upgradeData, Action callback)
        {
            OnSwitchButton.Invoke();
            OnSwitchButton = callback;
            var upgradePage = _upgradeSettings.FirstPage;
            upgradePage.UpdatePage(upgradeData, _upgradesDictionary[upgradeData], this);
        }

        public void BuyUpgrade(UpgradeData upgradeData, int level)
        {
            OnBuyUpgrade.Invoke(upgradeData, level);
            _upgradeSettings.UpgradeChannel.Fire(upgradeData, level);
        }

        public DecreaseBalanceUseCase BalanceUseCase { get; }
    }
}