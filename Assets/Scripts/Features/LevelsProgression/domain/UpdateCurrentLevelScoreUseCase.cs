using Features.LevelScore.domain;
using Zenject;

namespace Features.LevelsProgression.domain
{
    public class UpdateCurrentLevelScoreUseCase
    {
        [Inject] private CurrentScoreUseCase currentScoreUseCase;
        [Inject] private CurrentLevelScoreUseCase currentLevelScoreUseCase;
        public void UpdateScore()
        {
            var score = currentScoreUseCase.GetLastScore();
            currentLevelScoreUseCase.SetCurrentLevelScore(score);
        }
    }
}