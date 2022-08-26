using Features.BuildingsUpgrade.Interactions.Interfaces;
using Features.BuildingsUpgrade.Data;
using UnityEngine.UI;
using UnityEngine;

namespace Features.BuildingsUpgrade.Interactions
{
    public class MonoBuildingButton : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private Image image;

        public void Initialize(UpgradeData upgradeData, IBuildingView buildingView)
        {
            image.sprite = upgradeData.Sprite;
            button.onClick.AddListener(() => buildingView.OpenSkillPage(upgradeData));
        }
    }
}
