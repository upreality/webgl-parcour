using System;
using Features.Keys.domain;
using Features.Levels.presentation.respawn;
using UniRx;
using UnityEngine;
using Zenject;

namespace Features.Keys.data
{
    public class KeysSceneRepository: MonoBehaviour, IKeysRepository
    {
        [Inject] private IRespawnNavigator respawnNavigator;
        
        private readonly IntReactiveProperty keysCount = new(0);

        public IObservable<int> GetCollectedKeysCountFlow() => keysCount;

        private void Awake() => respawnNavigator.OnRespawn += DropKeysCounter;

        public void DropKeysCounter() => keysCount.Value = 0;

        public void AddKey() => keysCount.Value += 1;

        public void RemoveKey()
        {
            if (keysCount.Value <= 0)
                return;

            keysCount.Value -= 1;
        }

        private void OnDestroy() => respawnNavigator.OnRespawn -= DropKeysCounter;
    }
}