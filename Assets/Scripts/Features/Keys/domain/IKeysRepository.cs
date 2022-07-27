using System;

namespace Features.Keys.domain
{
    public interface IKeysRepository
    {
        public IObservable<int> GetCollectedKeysCountFlow();
        public void RemoveKey();
        public void AddKey();
    }
}