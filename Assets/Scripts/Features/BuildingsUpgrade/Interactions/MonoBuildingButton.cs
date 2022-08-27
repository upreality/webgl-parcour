using System.Collections.Generic;
using Features.BuildingsUpgrade.Interactions.Interfaces;
using Features.BuildingsUpgrade.Data;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

namespace Features.BuildingsUpgrade.Interactions
{
    public class MonoBuildingButton : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private TextMeshProUGUI price;
        [SerializeField] private Image image;

        public void Initialize(KeyValuePair<UpgradeData, int> dataPair, IBuildingView buildingView)
        {
            var upgrade = dataPair.Key;
            var level = dataPair.Value;

            image.sprite = upgrade.Sprite;
            
            if (level > 0)
            {
                price.gameObject.SetActive(false);
            }
            else
            {
                price.text = "50";
            }

            button.onClick.AddListener(() => buildingView.DisplayInfo(dataPair.Key));
        }
    }
}