using UnityEngine;
using Zenject;

namespace Features.Gameplay
{
    public class CompleteLevelHandler : MonoBehaviour
    {
        [Inject] private CompleteLevelNavigator navigator;

        public void CompleteCurrentLevel() => navigator.CompleteCurrentLevel();
    }
}