using System;
using Zenject;

namespace Features.GlobalScore.domain
{
    public class UpdateGlobalScoreUseCase
    {
        [Inject] private CalculateGlobalScoreUseCase calculateGlobalScoreUseCase;
        [Inject] private IGlobalScoreRepository globalScoreRepository;

        public IObservable<bool> UpdateGlobalScore()
        {
            var globalScore = calculateGlobalScoreUseCase.GetScore();
            return globalScoreRepository.SendScore(globalScore);
        }
    }
}