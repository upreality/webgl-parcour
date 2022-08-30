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

        public void UpdatePage(UpgradeData upgrade, int level, IBuildingView buildingView)
        {
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
                buyButton.gameObject.SetActive(true);
                buyButton.interactable = decreaseBalanceUseCase.GetCanDecreaseFlow(upgrade.Price, CurrencyType.Secondary)
                buyButton.onClick.RemoveAllListeners();
                buyButton.onClick.AddListener(() =>
                {
                    //TODO: upgrade.Price (building)
                    balanceRepository.GetBalance()
                    buildingView.BuyUpgrade(upgrade, 1);
                    buyButton.gameObject.SetActive(false);
                });
                costText.text = buyTextPrefix.GetText(languageProvider) + upgrade.Price;
            }
        }

        private void SetupBuyButton(UpgradeData upgrade, bool interactable, IBuildingView buildingView)
        {
            buyButton.interactable = interactable;
            buyButton.onClick.RemoveAllListeners();
            buyButton.onClick.AddListener(() =>
            {
                decreaseBalanceUseCase
                    .Decrease(upgrade.Price, CurrencyType.Secondary)
                    .Where(result => result == Success)
                    .Subscribe(_ =>
                        {
                            buildingView.BuyUpgrade(upgrade, 1);
                            buyButton.gameObject.SetActive(false);
                        }
                    ).AddTo(this);
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