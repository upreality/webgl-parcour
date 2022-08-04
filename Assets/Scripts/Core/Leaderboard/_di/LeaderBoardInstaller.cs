using Core.Leaderboard.data;
using Core.Leaderboard.domain;
using Core.Leaderboard.presentation;
using UnityEngine;
using Zenject;

namespace Core.Leaderboard._di
{
    public class LeaderBoardInstaller: MonoInstaller
    {
        [SerializeField] private LeaderBoardItemView leaderBoardItemView;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<PlayfabLeaderBoardRemoteDataSource>().AsSingle();
            Container.BindInterfacesAndSelfTo<LeaderBoardPlayfabRepository>().AsSingle();
            Container.BindFactory<LeaderBoardItemView, LeaderBoardItemView.Factory>().FromComponentInNewPrefab(leaderBoardItemView);
            Container.BindInterfacesAndSelfTo<LeaderBoardUseCase>().AsSingle();
        }
    }
} 