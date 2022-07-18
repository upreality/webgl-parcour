using Core.Analytics.session.domain;
using Features.Levels.domain.repositories;
using Zenject;

namespace Features.Levels.presentation.analytics
{
    public class SessionEventCurrentLevelIdProviderImpl: ISessionEventLevelIdProvider
    {
        [Inject] private ICurrentLevelRepository currentLevelRepository;
        public long GetCurrentLevelId() => currentLevelRepository.GetCurrentLevel().ID;
    }
}