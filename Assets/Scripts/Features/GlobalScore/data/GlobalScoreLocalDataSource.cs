using System;
using Plugins.FileIO;
using UniRx;
using Zenject;

namespace Features.GlobalScore.data
{
    public class GlobalScoreLocalDataSource
    {
        private const string Key = "USER_NAME_KEY";

        private readonly ReactiveProperty<int> scoreFlow;

        [Inject]
        public GlobalScoreLocalDataSource() => scoreFlow = new ReactiveProperty<int>(Score);

        private int Score
        {
            get => LocalStorageIO.HasKey(Key) ? LocalStorageIO.GetInt(Key) : 0;
            set
            {
                LocalStorageIO.SetInt(Key, value);
                scoreFlow.Value = value;
                LocalStorageIO.Save();
            }
        }

        public IObservable<int> GetScore() => scoreFlow;

        public void SendScore(int score) => Score = score;
    }
}