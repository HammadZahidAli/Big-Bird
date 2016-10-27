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
    public static int count = 1;

	// Use this for initialization
	void Start () {
        Analytics.CustomEvent("gameOver", new Dictionary<string, object>
  {
    { "bird", ShopManager.selectedbird },
    { "coins", GameOverManager.temScore }
  
  });

        //if (count % 2 == 0)
       

       // count++;
    }
    // Reference the Collections Generic namespace


  int totalPotions = 5;
int totalCoins = 100;


    void OnEnable()
    {

        scoreText.text = ScoreManagerScript.Score.ToString();

       // Debug.Log("total: "+ totalScore);

        totalScore = PlayerPrefs.GetInt("totalScore");
        highScore = PlayerPrefs.GetInt("highScore");

        if(ScoreManagerScript.Score > highScore)
        {
            highScore = ScoreManagerScript.Score;
            
        }
        highScoreText.text = highScore.ToString();
        totalScore += ScoreManagerScript.Score;

        PlayerPrefs.SetInt("highScore", highScore);
        PlayerPrefs.SetInt("totalScore", totalScore);
        PlayerPrefs.Save();

        
        Invoke("Do",1f);

        count++;
    }

    void Do()
    {

        if (count % 6 == 0)
            UnityAdsManager.Instance.ShowVideoAd();


        AdBuddizBinding.ShowAd();

        
    }





    public void OnClickPosttoLeaderboard()
    {
        LeaderboardManager.ReportScore(highScore);
    }

    //On Coins Revive
    public void OnClick50Coins()
    {
        totalScore -= ScoreManagerScript.Score;
        if (totalScore >= 10)
        {
            totalScore -= 10;
            PlayerPrefs.SetInt("totalScore", totalScore);
            revive = true;
            temScore = ScoreManagerScript.Score;
            Debug.Log("score:"+temScore);
            MainMenuManager.Instance.RestartEvent();
            PlayerPrefs.Save();
            
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
