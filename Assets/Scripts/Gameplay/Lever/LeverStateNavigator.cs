using System;
using Levels.presentation.respawn;
using UniRx;
using UnityEngine;
using Zenject;

namespace Gameplay.Lever
{
    public class LeverStateNavigator : MonoBehaviour
    {
        [Inject] private IRespawnNavigator respawnNavigator;
        private BehaviorSubject<bool> leverState = new(false);

        public IObservable<bool> GetLeverState() => leverState;

        private void Start() => respawnNavigator.OnRespawn += DropState;
        
        public void SelectLever() => leverState.OnNext(true);

        private void DropState() => leverState.OnNext(false);

        private void OnDestroy() => respawnNavigator.OnRespawn -= DropState;
    }
}
