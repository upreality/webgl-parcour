using Features.LevelsProgression.domain;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Features.LevelsProgression.presentation.ui
{
    [RequireComponent(typeof(Button))]
    public class CompleteCurrentLevelDebugButton : MonoBehaviour
    {
        [Inject] private CompleteCurrentLevelUseCase completeCurrentLevelUseCase;

        private void Start()
        {
            GetComponent<Button>().onClick.AddListener(
                () => completeCurrentLevelUseCase.CompleteCurrentLevel().Subscribe().AddTo(this)
            );
        }
    }
}