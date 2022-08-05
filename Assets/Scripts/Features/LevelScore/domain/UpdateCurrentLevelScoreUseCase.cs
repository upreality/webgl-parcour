using System;
using Features.LevelTime.domain;
using Zenject;

namespace Features.LevelScore.domain
{
    public class UpdateCurrentLevelScoreUseCase
    {
        [Inject] private CurrentScoreUseCase currentScoreUseCase;
        [Inject] private LastLevelScoreUseCase lastLevelScoreUseCase;
        [Inject] private ILevelTimerRepository timerRepository;
        
        public IObservable<bool> UpdateScore()
        {
            timerRepository.StopTimer();
            var score = currentScoreUseCase.GetLastScore();
            return lastLevelScoreUseCase.SetScore(score);
        }
    }
}