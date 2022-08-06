using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

namespace Features.Death
{
    public class DeathCountText : MonoBehaviour
    {
        [Inject] private IDeathCounterRepository deathCounterRepository;

        [SerializeField] private TextMeshPro text;
        [SerializeField] private string textTemplate;

        private void Start() => deathCounterRepository.GetDeathCountFlow().Subscribe(UpdateText).AddTo(this);

        private void UpdateText(int deathCount)
        {
            var countText = deathCount > 999 ? "999+" : deathCount.ToString();
            text.text = textTemplate.Replace("$", countText);
        }
    }
}