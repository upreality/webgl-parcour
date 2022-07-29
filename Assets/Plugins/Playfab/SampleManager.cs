using PlayFab;
using PlayFab.ClientModels;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SampleManager : MonoBehaviour
{
	public InputField inputScoreObject;

	private Dictionary<string, int> GameStats = new Dictionary<string, int>();

	void Start()
	{
		if (PlayfabManager.IsLoggedIn == false)
		{
			PlayfabManager.Login(OnLoginSuccess, OnLoginFailed);
		}
	}

	private void OnLoginSuccess(LoginResult result)
	{
		RefreshLeaderboards();
	}

	private void OnGotLeaderboards()
	{
		GoToLeaderboards();
	}

	private void OnGotLeaderboardsFailed()
	{
		Debug.LogError("ERROR: Failed to retrieve Leaderboards. Verify configuration on PlayFab GameManager matches the supplied documentation.");
	}

	private void OnLoginFailed(PlayFabError error)
	{
		Debug.LogError("ERROR: Login Failed. Verify Title ID is set correctly.");
		Debug.LogError(error.GenerateErrorReport());
	}

	// Selected leaderboard
	private int CurrentLeaderboard = 0;

	// UX strings for the leaderboards
	private string[,] LeaderboardInfo = new string[,]
	{
		{ "best_time", "Best Time", "Seconds" },
		{ "high_score", "High Scores", "Points" },
		{ "total_score", "Total Scores", "Total Points" }
	};

	public void RefreshLeaderboards()
	{
		PlayfabManager.LoadLeaderboards(OnGotLeaderboards, OnGotLeaderboardsFailed);
	}

	public void GoToLeaderboards()
	{
		ShowLeaderboard(CurrentLeaderboard);
	}

	private void ShowLeaderboard(int boardIndex)
	{
		var list = GameObject.Find("Score List");
		var script = list.GetComponent<ScoreList>();

		script.ShowLeaderboard(
			LeaderboardInfo[CurrentLeaderboard, 0],
			LeaderboardInfo[CurrentLeaderboard, 1],
			LeaderboardInfo[CurrentLeaderboard, 2]
			);
	}

	public void PostNewScore()
	{
		int value;
		if (int.TryParse(inputScoreObject.text, out value))
		{
			Debug.Log(string.Format("PostNewScore: Posted new score of {0}", value));
			PlayfabManager.UpdateStatistic("total_score", value);
		}
		else
		{
			Debug.Log(string.Format("Warning: Invalid Numeric Value: {0}", inputScoreObject.text));
		}
	}
}
