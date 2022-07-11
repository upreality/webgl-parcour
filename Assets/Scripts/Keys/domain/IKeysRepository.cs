using System;

namespace Keys.domain
{
    public interface IKeysRepository
    {
        public IObservable<int> GetCollectedKeysCountFlow();
        public void RemoveKey();
        public void AddKey();
    }
}