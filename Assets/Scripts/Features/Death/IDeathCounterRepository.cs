using System;

namespace Features.Death
{
    public interface IDeathCounterRepository
    {
        public IObservable<int> GetDeathCountFlow();
        void CountDeath();
    }
}