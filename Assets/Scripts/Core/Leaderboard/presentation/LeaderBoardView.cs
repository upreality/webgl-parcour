using System.Collections.Generic;
using Core.Auth.domain;
using Core.Leaderboard.domain;
using UniRx;
using UnityEngine;
using Zenject;

namespace Core.Leaderboard.presentation
{
    public abstract class LeaderBoardView : MonoBehaviour
    {
        [Inject] private LeaderBoardUseCase leaderBoardUseCase;
        [Inject] private IAuthRepository authRepository;
        [Inject] private LeaderBoardItemView.Factory itemFactory;

        [SerializeField] private RectTransform root;

        protected abstract string GetLeaderBoardId();

        private void OnEnable()
        {
            foreach (Transform child in root) Destroy(child.gameObject);
            var leaderBoardId = GetLeaderBoardId();
            leaderBoardUseCase
                .GetPositionsAroundPlayer(leaderBoardId)
                .Subscribe(SpawnItems)
                .AddTo(this);
        }

        private void SpawnItems(List<LeaderBoardItem> items)
        {
            foreach (var item in items)
            {
                var itemView = itemFactory.Create();
                var viewTransform = itemView.transform;
                viewTransform.SetParent(root);
                viewTransform.localScale = Vector3.one;
                itemView.Setup(item, item.PlayerId == authRepository.LoginUserId);
            }
        }
    }
}