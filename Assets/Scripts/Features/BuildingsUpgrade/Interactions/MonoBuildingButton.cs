using System;
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
        private UnityEngine.UI.Outline _outline;

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
                price.text = upgrade.Price.ToString();
            }

            button.onClick.AddListener(() =>
            {
                _outline.enabled = true;
                buildingView.DisplayInfo(dataPair.Key, () => { _outline.enabled = false;});
            });
        }

        private void Start()
        {
            _outline = GetComponent<UnityEngine.UI.Outline>();
        }
    }
}