using Features.LevelsProgression.domain;
using UnityEngine;
using Zenject;

namespace Features.LevelsProgression._di
{
    public class LevelsProgressionInstaller : MonoInstaller
    {
        [SerializeField] private CompleteLevelNavigator completeLevelNavigator;

        public override void InstallBindings()
        {
            Container.Bind<CompleteCurrentLevelUseCase>().ToSelf().AsSingle();
            Container.Bind<LevelLeaderboardUseCase>().ToSelf().AsSingle();
            Container.Bind<CurrentLevelLeaderBoardUseCase>().ToSelf().AsSingle();
            Container.Bind<CurrentScoreUseCase>().ToSelf().AsSingle();
            Container.Bind<UpdateCurrentLevelScoreUseCase>().ToSelf().AsSingle();
            Container.BindInstance(completeLevelNavigator).AsSingle();
        }
    }
}