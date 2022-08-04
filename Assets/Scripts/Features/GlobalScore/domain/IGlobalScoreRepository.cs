using System;

namespace Features.GlobalScore.domain
{
    public interface IGlobalScoreRepository
    {
        public IObservable<int> GetScore();
        public IObservable<bool> SendScore(int score);
    }
}