using System;
using Core.Localization;
using Core.Localization.LanguageProviders;
using Core.Localization.presentation;
using Features.Balance.domain;
using Features.BuildingsUpgrade.Data;
using Features.BuildingsUpgrade.Interactions.Interfaces;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using static Features.Balance.domain.DecreaseBalanceUseCase.DecreaseBalanceResult;

namespace Features.BuildingsUpgrade.Pages
{
    public class MonoUpgradePage : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI buildingName;
        [SerializeField] private TextMeshProUGUI buildingDescription;
        [SerializeField] private Image skillSprite;
        [SerializeField] private TextMeshProUGUI skillName;
        [SerializeField] private TextMeshProUGUI skillDescription;
        [SerializeField] private TextMeshProUGUI costText;
        [SerializeField] private Button buyButton;
        [SerializeField] private TextMeshProUGUI skillsText;

        [SerializeField] private Button skillsButton;

        //TODO: provide languageProvider via DI
        private readonly ILanguageProvider languageProvider = new DefaultLanguageProvider();

        [Header("Localization")] 
        [SerializeField] private SimpleLocalizedTextProvider buySkillsText;
        [SerializeField] private SimpleLocalizedTextProvider allSkillsText;
        [SerializeField] private SimpleLocalizedTextProvider buyTextPrefix;
        [SerializeField] private SimpleLocalizedTextProvider skillPostfixText;

        [Inject] private DecreaseBalanceUseCase decreaseBalanceUseCase;

        private Subject<int> priceSubject = new();

        private void Awake()
        {
            priceSubject
                .Select(price => decreaseBalanceUseCase.GetCanDecreaseFlow(price, CurrencyType.Secondary))
                .Switch()
                .Subscribe(canBuy => buyButton.interactable = canBuy)
                .AddTo(this);
        }

        public void UpdatePage(UpgradeData upgrade, int level, IBuildingView buildingView)
        {
            priceSubject.OnNext(upgrade.Price);
            buildingName.text = upgrade.Name;
            skillsButton.onClick.RemoveAllListeners();
            skillsButton.onClick.AddListener(() => { buildingView.OpenSkillPage(upgrade); });
            if (level > 0)
            {
                skillsText.text = buySkillsText.GetText(languageProvider);
                UpdateSkillInfo(upgrade.Skills[level - 1], level);
                buyButton.gameObject.SetActive(false);
            }
            else
            {
                var firstSkill = upgrade.Skills[0];
                skillsText.text = allSkillsText.GetText(languageProvider);
                UpdateSkillInfo(firstSkill, level);
                costText.text = buyTextPrefix.GetText(languageProvider) + upgrade.Price;
                SetupBuyButton(upgrade,purchaseResult =>
                {
                    if(!purchaseResult) return;
                    buildingView.BuyUpgrade(upgrade, 1);
                    buyButton.gameObject.SetActive(false);
                });
            }
        }

        private void SetupBuyButton(UpgradeData upgrade, Action<bool> onBought)
        {
            buyButton.gameObject.SetActive(true);
            buyButton.onClick.RemoveAllListeners();
            buyButton.onClick.AddListener(() =>
            {
                decreaseBalanceUseCase
                    .Decrease(upgrade.Price, CurrencyType.Secondary)
                    .Subscribe(result => onBought(result == Success))
                    .AddTo(this);
            });
        }

        private void UpdateSkillInfo(SkillData skillData, int number)
        {
            skillName.text = number + skillPostfixText.GetText(languageProvider);
            skillDescription.text = skillData.Description;
            skillSprite.sprite = skillData.Sprite;
        }
    }
}