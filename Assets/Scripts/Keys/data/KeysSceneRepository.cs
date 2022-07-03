using System;
using Gameplay.Keys.domain;
using UniRx;
using UnityEngine;

namespace Keys.data
{
    public class KeysSceneRepository : MonoBehaviour, IKeysRepository
    {
        private readonly IntReactiveProperty keysCount = new(0);

        public IObservable<int> GetCollectedKeysCountFlow() => keysCount;

        public void DropKeysCounter() => keysCount.Value = 0;

        public void AddKey() => keysCount.Value += 1;

        public void RemoveKey()
        {
            if (keysCount.Value <= 0)
                return;

            keysCount.Value -= 1;
        }
    }
}