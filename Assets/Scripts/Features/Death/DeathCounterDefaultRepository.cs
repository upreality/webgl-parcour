using System;
using Plugins.FileIO;
using UniRx;

namespace Features.Death
{
    public class DeathCounterDefaultRepository : IDeathCounterRepository
    {
        private const string KEY_PREFIX = "DeathCount";

        private static int DeathCount
        {
            get => LocalStorageIO.GetInt(KEY_PREFIX, 0);
            set => LocalStorageIO.SetInt(KEY_PREFIX, value);
        }

        private readonly ReactiveProperty<int> deathCountFlow = new(DeathCount);

        IObservable<int> IDeathCounterRepository.GetDeathCountFlow() => deathCountFlow;

        void IDeathCounterRepository.CountDeath() => deathCountFlow.Value = ++DeathCount;
    }
}