using Levels.domain;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Levels.presentation.ui
{
    [RequireComponent(typeof(Button))]
    public class CompleteCurrentLevelDebugButton : MonoBehaviour
    {
        [Inject] private CompleteCurrentLevelUseCase completeCurrentLevelUseCase;

        private void Start()
        {
            GetComponent<Button>().onClick.AddListener(
                () => completeCurrentLevelUseCase.CompleteCurrentLevel()
            );
        }
    }
}