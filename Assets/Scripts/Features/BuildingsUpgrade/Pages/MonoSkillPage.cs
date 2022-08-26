using System;
using Features.BuildingsUpgrade.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Features.BuildingsUpgrade.Pages
{
    public class MonoSkillPage : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI skillName;
        [SerializeField] private TextMeshProUGUI description;
        [SerializeField] private Button[] buttons;

        private UpgradeData _upgradeData;

        public void SetButtons(int activeCount, int count)
        {
            if (activeCount > count) throw new ArgumentException("active > count");

            for (var i = 0; i < count - 1; i++)
            {
                buttons[i].gameObject.SetActive(true);
                buttons[i].interactable = i < activeCount;
            }
        }

        public void Initialize(UpgradeData upgradeData)
        {
            _upgradeData = upgradeData;
        }

        private void ChangeSkill(int id)
        {
            Debug.Log(id);
            var data = _upgradeData.Skills[id];
            skillName.text = data.Name;
            description.text = data.Description;
        }
        
        private void Start()
        {
            for (int i = 0; i < buttons.Length - 1; i++)
            {
                var i1 = i;
                buttons[i].onClick.AddListener(() => ChangeSkill(i1));
            }
        }
    }
}