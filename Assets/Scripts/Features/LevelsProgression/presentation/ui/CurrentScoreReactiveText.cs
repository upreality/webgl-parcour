using Features.LevelsProgression.domain;
using UniRx;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;

namespace Features.LevelsProgression.presentation.ui
{
    public class CurrentScoreReactiveText : MonoBehaviour
    {
        [Inject] private CurrentScoreUseCase currentScoreUseCase;

        [SerializeField] private Text text;
        [SerializeField] private UnityEvent onUpdateText;

        private void Awake()
        {
            if (text == null)
                text = GetComponent<Text>();
        }

        private void Start() => currentScoreUseCase.GetCurrentScoreFlow().Subscribe(UpdateScore).AddTo(this);

        private void UpdateScore(int score)
        {
            text.text = score.ToString();
            onUpdateText?.Invoke();
        }
    }
}