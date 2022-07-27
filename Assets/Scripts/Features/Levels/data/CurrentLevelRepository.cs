using System;
using Features.Levels.domain.model;
using Features.Levels.domain.repositories;
using UniRx;
using Zenject;

namespace Features.Levels.data
{
    internal class CurrentLevelRepository : ICurrentLevelRepository
    {
        private ILevelsRepository levelsRepository;
        private ICurrentLevelIdDao currentLevelIdDao;
        private IDefaultLevelIdDao defaultLevelIdDao;

        private BehaviorSubject<long> currentLevelIdSubject;

        private long CurrentLevelId => currentLevelIdDao.HasCurrentLevelId()
            ? currentLevelIdDao.GetCurrentLevelId()
            : defaultLevelIdDao.GetDefaultLevelId();

        [Inject]
        public CurrentLevelRepository(
            ILevelsRepository levelsRepository,
            ICurrentLevelIdDao currentLevelIdDao,
            IDefaultLevelIdDao defaultLevelIdDao)
        {
            this.levelsRepository = levelsRepository;
            this.currentLevelIdDao = currentLevelIdDao;
            this.defaultLevelIdDao = defaultLevelIdDao;
            currentLevelIdSubject = new BehaviorSubject<long>(CurrentLevelId);
        }

        public void SetCurrentLevel(long levelId)
        {
            currentLevelIdDao.SetCurrentLevelId(levelId);
            currentLevelIdSubject.OnNext(levelId);
        }

        public Level GetCurrentLevel() => levelsRepository.GetLevel(CurrentLevelId);

        public IObservable<Level> GetCurrentLevelFlow() => currentLevelIdSubject.Select(levelsRepository.GetLevel);

        public interface ICurrentLevelIdDao
        {
            public bool HasCurrentLevelId();
            public long GetCurrentLevelId();
            public void SetCurrentLevelId(long id);
        }

        public interface IDefaultLevelIdDao
        {
            public long GetDefaultLevelId();
        }
    }
}