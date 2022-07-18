using UnityEngine;
using Zenject;

namespace Core.SDK.GameState
{
    public class GameStateMenu : MonoBehaviour
    {
        [Inject] private GameStateNavigator gameStateNavigator;

        private void OnEnable() => gameStateNavigator.SetMenuShownState(true);

        private void OnDisable() => gameStateNavigator.SetMenuShownState(false);
    }
}