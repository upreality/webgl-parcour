using Features.Keys.domain;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Features.Keys.presentation
{
    public class KeysUIView : MonoBehaviour
    {
        [Inject] private IKeysRepository keysRepository;
        [SerializeField] private GameObject viewRoot;
        [SerializeField] private Text countText;

        private void Start() => keysRepository
            .GetCollectedKeysCountFlow()
            .Subscribe(UpdateKeysCount)
            .AddTo(this);

        private void UpdateKeysCount(int count)
        {
            viewRoot.SetActive(count > 0);
            countText.text = count.ToString();
        }
    }
}