using Features.Levels.domain.repositories;
using Features.LevelScore.domain.model;
using Zenject;

namespace Features.LevelScore.domain
{
    public class CurrentLevelScoreUseCase
    {
        [Inject] private ICurrentLevelRepository currentLevelRepository;
        [Inject] private ILevelScoreRepository scoreRepository;

        private long CurrentLevelId => currentLevelRepository.GetCurrentLevel().ID;

        public int GetCurrentLevelScore(ScoreType scoreType) => scoreRepository.GetScore(CurrentLevelId, scoreType);

        public void SetCurrentLevelScore(int score) => scoreRepository.UpdateScore(CurrentLevelId, score);
    }
}