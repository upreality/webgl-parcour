using Features.BuildingsUpgrade.Interactions.Interfaces;
using System.Collections.Generic;
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
            if (upgrade.IsHub)
            {
                if (_outline)
                {
                    _outline.enabled = true;
                }
                else
                {
                    _outline = GetComponent<UnityEngine.UI.Outline>();
                    _outline.enabled = true;
                }

                buildingView.DisplayInfo(dataPair.Key, () => { _outline.enabled = false; });
            }

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
                buildingView.DisplayInfo(dataPair.Key, () => { _outline.enabled = false; });
                _outline.enabled = true;
            });
        }

        private void Start()
        {
            _outline = GetComponent<UnityEngine.UI.Outline>();
        }
    }
}