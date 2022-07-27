using System;

namespace Features.Gameplay.Death
{
    public interface IDeathCounterRepository
    {
        public IObservable<int> GetDeathCountFlow();
        void CountDeath();
    }
}