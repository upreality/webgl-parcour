using System;

namespace Gameplay.Death
{
    public interface IDeathCounterRepository
    {
        public IObservable<int> GetDeathCountFlow();
        void CountDeath();
    }
}