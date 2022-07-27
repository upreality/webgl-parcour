using System.Collections.Generic;
using Doozy.Engine.UI;
using Features.Keys.domain;
using UniRx;
using UnityEngine;
using Zenject;

namespace Features.Keys.presentation
{
    public class KeysUIView : MonoBehaviour
    {
        [Inject] private IKeysRepository keysRepository;
        [SerializeField] private List<UIView> keyViews = new();

        private void Start() => keysRepository
            .GetCollectedKeysCountFlow()
            .Subscribe(UpdateKeysCount)
            .AddTo(this);

        private void UpdateKeysCount(int count)
        {
            for (var i = 0; i < keyViews.Count; i++)
            {
                SetVisibleState(keyViews[i], i < count);
            }
        }

        private void SetVisibleState(UIView view, bool state)
        {
            var isVisible = view.Visibility is VisibilityState.Visible or VisibilityState.Showing;
            if (isVisible == state)
                return;

            if (view.gameObject.activeInHierarchy)
            {
                if (state) view.Show();
                else view.Hide();
            }
            else
            {
                view.gameObject.SetActive(state);
            }
            
        }
    }
}