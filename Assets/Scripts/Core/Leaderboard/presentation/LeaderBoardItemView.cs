using Core.Leaderboard.domain;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Core.Leaderboard.presentation
{
    public class LeaderBoardItemView: MonoBehaviour
    {
        [SerializeField] private Text posText;
        [SerializeField] private Text scoreText;
        [SerializeField] private GameObject currentUserOutline;

        public void Setup(LeaderBoardItem item, bool isCurrentPlayer)
        {
            posText.text = item.Position + " " + item.PlayerName;
            scoreText.text = item.Score.ToString();
            currentUserOutline.SetActive(isCurrentPlayer);
        }
        
        public class Factory : PlaceholderFactory<LeaderBoardItemView>
        {
        }
    }
}