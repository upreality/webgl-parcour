using Core.Localization;
using Core.Localization.presentation;
using Features.BuildingsUpgrade.Interactions.Interfaces;
using Features.BuildingsUpgrade.Data;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using Zenject;

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
        [Header("Localization")] [Inject] private ILanguageProvider languageProvider;
        [SerializeField] private SimpleLocalizedTextProvider buySkillsText;
        [SerializeField] private SimpleLocalizedTextProvider allSkillsText;
        [SerializeField] private SimpleLocalizedTextProvider lastSkillText;
        [SerializeField] private SimpleLocalizedTextProvider buyTextPrefix;
        [SerializeField] private SimpleLocalizedTextProvider skillPostfixText;

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
                skillsText.text = allSkillsText.GetText(languageProvider);
                UpdateSkillInfo(upgrade.Skills[^1], level);
                skillName.text = lastSkillText.GetText(languageProvider);
                buyButton.gameObject.SetActive(true);
                buyButton.onClick.RemoveAllListeners();
                buyButton.onClick.AddListener(() =>
                {
                    //TODO: upgrade.Price (building)
                    buildingView.BuyUpgrade(upgrade, 1);
                    buyButton.gameObject.SetActive(false);
                });
                costText.text = buyTextPrefix.GetText(languageProvider) + upgrade.Price;
            }
        }

        private void UpdateSkillInfo(SkillData skillData, int number)
        {
            skillName.text = number + skillPostfixText.GetText(languageProvider);
            skillDescription.text = skillData.Description;
            skillSprite.sprite = skillData.Sprite;
        }
    }
}