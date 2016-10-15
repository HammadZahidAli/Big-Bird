using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using AppAdvisory.social;

public class UpdateHighScore : MonoBehaviour {

    public Text highScoreText;
    public Text totalScoreText;

    void OnEnable()
    {

        Debug.Log("update total " + GameOverManager.totalScore);
        highScoreText.text = "High Score : " + PlayerPrefs.GetInt("highScore").ToString();
        totalScoreText.text = "Total Score : " + GameOverManager.totalScore.ToString();
    }


    public void OnClickShowLeaderBoard()
    {
        LeaderboardManager.ShowLeaderboardUI();
    }

    public void OnClickReportLeaderBoard()
    {
        LeaderboardManager.ReportScore(20);
    }


}
