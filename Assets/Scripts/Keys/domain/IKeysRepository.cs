using System;

namespace Gameplay.Keys.domain
{
    public interface IKeysRepository
    {
        public IObservable<int> GetCollectedKeysCountFlow();
    }
}