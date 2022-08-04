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
        private ICurrentLevelIdDataSource currentLevelIdDataSource;
        private IDefaultLevelIdDao defaultLevelIdDao;

        private BehaviorSubject<long> currentLevelIdSubject;

        private long CurrentLevelId => currentLevelIdDataSource.HasCurrentLevelId()
            ? currentLevelIdDataSource.GetCurrentLevelId()
            : defaultLevelIdDao.GetDefaultLevelId();
        
        private long PrevLevelId => currentLevelIdDataSource.HasCurrentLevelId()
            ? currentLevelIdDataSource.GetPrevLevelId()
            : defaultLevelIdDao.GetDefaultLevelId();

        [Inject]
        public CurrentLevelRepository(
            ILevelsRepository levelsRepository,
            ICurrentLevelIdDataSource currentLevelIdDataSource,
            IDefaultLevelIdDao defaultLevelIdDao)
        {
            this.levelsRepository = levelsRepository;
            this.currentLevelIdDataSource = currentLevelIdDataSource;
            this.defaultLevelIdDao = defaultLevelIdDao;
            currentLevelIdSubject = new BehaviorSubject<long>(CurrentLevelId);
        }

        public void SetCurrentLevel(long levelId)
        {
            currentLevelIdDataSource.SetCurrentLevelId(levelId);
            currentLevelIdSubject.OnNext(levelId);
        }

        public Level GetCurrentLevel() => levelsRepository.GetLevel(CurrentLevelId);
        public Level GetPrevLevel() => levelsRepository.GetLevel(PrevLevelId);

        public IObservable<Level> GetCurrentLevelFlow() => currentLevelIdSubject.Select(levelsRepository.GetLevel);

        public interface ICurrentLevelIdDataSource
        {
            public bool HasCurrentLevelId();
            public long GetCurrentLevelId();
            public long GetPrevLevelId();
            public void SetCurrentLevelId(long id);
        }

        public interface IDefaultLevelIdDao
        {
            public long GetDefaultLevelId();
        }
    }
}