using Ads.presentation.InterstitialAdNavigator;
using Doozy.Engine;
using Levels.domain;
using UnityEngine;
using Zenject;

namespace Levels.presentation
{
    public class CompleteLevelController : MonoBehaviour, ILevelCompletedListener
    {
        [SerializeField] private string uiEventName = "LevelCompleted";
        [Inject] private CompleteCurrentLevelUseCase completeCurrentLevelUseCase;
        [Inject] private IInterstitialAdNavigator adNavigator;

        public void CompleteCurrentLevel()
        {
            completeCurrentLevelUseCase.CompleteCurrentLevel();
            adNavigator.ShowAd().Subscribe(_ => )
        }
    }
}