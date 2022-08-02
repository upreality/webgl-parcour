using Core.Analytics.session.domain;
using Features.Levels.adapters;
using Features.Levels.data;
using Features.Levels.data.dao;
using Features.Levels.domain;
using Features.Levels.domain.repositories;
using Features.Levels.presentation.analytics;
using UnityEngine;
using Zenject;

namespace Features.Levels._di
{
    [CreateAssetMenu(menuName = "Installers/LevelsBaseInstaller")]
    public class LevelsBaseInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private SimpleLevelsDao levelsDao;

        public override void InstallBindings()
        {
            //Daos
            Container.Bind<ILevelCompletedStateDao>()
#if PLAYER_PREFS_STORAGE
                .To<PlayerPrefsLevelCompletedStateDao>()
#else
                .To<LocalStorageLevelCompletedStateDao>()
#endif
                .AsSingle();


            Container.Bind<LevelsRepository.ILevelsDao>().FromInstance(levelsDao).AsSingle();

            Container.Bind<CurrentLevelRepository.ICurrentLevelIdDao>()
#if PLAYER_PREFS_STORAGE
                .To<PlayerPrefsCurrentLevelIdDao>()
#else
                .To<LocalStorageCurrentLevelIdDao>()
#endif
                .AsSingle();


            Container.Bind<CurrentLevelRepository.IDefaultLevelIdDao>().To<HardcodedDefaultLevelIdDao>().AsSingle();
            //Repositories
            Container.Bind<ILevelsRepository>().To<LevelsRepository>().AsCached();
            Container.Bind<ILevelSceneObjectRepository>().To<LevelsRepository>().AsCached();
            Container.Bind<ICurrentLevelRepository>().To<CurrentLevelRepository>().AsSingle();
            Container.Bind<ILevelCompletedStateRepository>().To<LevelCompletedStateRepository>().AsSingle();
            //UseCases
            Container.Bind<CompleteCurrentLevelUseCase>().ToSelf().AsSingle();
            Container.Bind<SetNextCurrentLevelUseCase>().ToSelf().AsSingle();
            Container.Bind<LevelLeaderboardUseCase>().ToSelf().AsSingle();
            //Adapters
            Container
                .Bind<CompleteCurrentLevelUseCase.IRewardHandler>()
                .To<StubLevelRewardHandlerAdapter>()
                .AsSingle();
            Container
                .Bind<ISessionEventLevelIdProvider>()
                .To<SessionEventCurrentLevelIdProviderImpl>()
                .AsSingle();
        }
    }
}