using UniRx;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Gameplay.Lever
{
    public class LeverStateListener: MonoBehaviour
    {
        [Inject] private LeverStateNavigator leverStateNavigator;
        [SerializeField] private UnityEvent onEnabled;
        [SerializeField] private UnityEvent onDisabled;

        private void Start() => leverStateNavigator.GetLeverState().Subscribe(UpdateState).AddTo(this);
        
        private void UpdateState(bool isEnabled)
        {
            var currentEvent = isEnabled ? onEnabled : onDisabled;
            currentEvent?.Invoke();
        }
    }
}