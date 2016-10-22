using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
// Reference the Unity Analytics namespace
using UnityEngine.Analytics;

using AppAdvisory.social;

public class GameOverManager : MonoBehaviour {

    public Text scoreText;
    public Text highScoreText;
    
    public static int highScore;
    public static int totalScore;
    public static bool revive;
    public static int temScore;
	// Use this for initialization
	void Start () {
        Analytics.CustomEvent("gameOver", new Dictionary<string, object>
  {
    { "bird", ShopManager.selectedbird },
    { "coins", GameOverManager.temScore }
  
  });

        AdBuddizBinding.ShowAd();
    }
    // Reference the Collections Generic namespace


  int totalPotions = 5;
int totalCoins = 100;


    void OnEnable()
    {

        scoreText.text = ScoreManagerScript.Score.ToString();
        

        totalScore = PlayerPrefs.GetInt("totalScore");
        highScore = PlayerPrefs.GetInt("highScore");

        if(ScoreManagerScript.Score > highScore)
        {
            highScore = ScoreManagerScript.Score;
            LeaderboardManager.ReportScore(highScore);
        }
        highScoreText.text = highScore.ToString();
        totalScore += ScoreManagerScript.Score;

        PlayerPrefs.SetInt("highScore", highScore);
        PlayerPrefs.SetInt("totalScore", totalScore);
    }


    //On Coins Revive
    public void OnClick50Coins()
    {
        totalScore -= ScoreManagerScript.Score;
        if (totalScore >= 50)
        {
            totalScore -= 50;
            PlayerPrefs.SetInt("totalScore", totalScore);
            revive = true;
            temScore = ScoreManagerScript.Score;
            Debug.Log("score:"+temScore);
            MainMenuManager.Instance.RestartEvent();

            
        }
        else
            totalScore += ScoreManagerScript.Score;

        PlayerPrefs.Save();

    }


    public void OnClickAd()
    {
        totalScore -= ScoreManagerScript.Score;
        PlayerPrefs.SetInt("totalScore", totalScore);

        //Application.LoadLevel(Application.loadedLevel);
        UnityAdsManager.Instance.ShowRewardedVideoAd();

        PlayerPrefs.Save();
    }






}
