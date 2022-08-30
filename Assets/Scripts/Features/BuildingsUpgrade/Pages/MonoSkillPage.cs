using System;
using Features.BuildingsUpgrade.Data;
using Features.BuildingsUpgrade.Interactions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Features.BuildingsUpgrade.Pages
{
    public class MonoSkillPage : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI skillName;
        [SerializeField] private TextMeshProUGUI description;
        [SerializeField] private Image image;
        [SerializeField] private Button[] buttons;
        [SerializeField] private Button buyButton;
        [SerializeField] private TextMeshProUGUI[] upgradeTexts;

        private UnityEngine.UI.Outline[] _buttonOutline;
        private BuildingView _buildingView;
        private UpgradeData _upgradeData;
        private int _lockedId;
        private int _count;

        public void SetButtons(int activeCount, int count)
        {
            if (activeCount > count) throw new ArgumentException("active > count");
            _count = count;

            for (var i = 0; i < count; i++)
            {
                buttons[i].gameObject.SetActive(true);
                buttons[i].interactable = true;
                upgradeTexts[i].text = _upgradeData.Skills[i].Price.ToString();
            }

            if (activeCount == _count || activeCount == 0)
            {
                ChangeSkill(_count - 1);
                _lockedId = int.MaxValue;
                buyButton.gameObject.SetActive(false);
            }
            else
            {
                _lockedId = activeCount;
                ChangeSkill(activeCount);
                buyButton.gameObject.SetActive(true);
            }
        }

        public void Initialize(UpgradeData upgradeData, BuildingView buildingView)
        {
            _buildingView = buildingView;
            _upgradeData = upgradeData;
            foreach (var button in buttons)
            {
                button.gameObject.SetActive(false);
            }

            buyButton.gameObject.SetActive(false);
        }

        private void ChangeSkill(int id)
        {
            var data = _upgradeData.Skills[id];
            image.sprite = data.Sprite;
            skillName.text = data.Name;
            description.text = data.Description;
            buyButton.gameObject.SetActive(id == _lockedId);
            SetActiveOutline(id);            
            
            if (id != _lockedId) return;
            
            //TODO: data.Price
            buyButton.onClick.RemoveAllListeners();
            buyButton.onClick.AddListener(() =>
            {
                _buildingView.BuyUpgrade(_upgradeData, id + 1);
                buyButton.gameObject.SetActive(false);
                SetButtons(id + 1, _count);
            });

        }

        private void SetActiveOutline(int id)
        {
            if (_buttonOutline == null)
            {
                _buttonOutline = new UnityEngine.UI.Outline[buttons.Length];
                for (var i = 0; i < buttons.Length; i++)
                {
                    _buttonOutline[i] = buttons[i].GetComponent<UnityEngine.UI.Outline>();
                }
            }
            for (var i = 0; i < _buttonOutline.Length; i++)
            {
                _buttonOutline[i].enabled = false;
            }

            _buttonOutline[id].enabled = true;
        }

        private void Awake()
        {
            for (var i = 0; i < buttons.Length - 1; i++)
            {
                var id = i;
                buttons[i].onClick.AddListener(() => { ChangeSkill(id); });
            }
        }
    }
}