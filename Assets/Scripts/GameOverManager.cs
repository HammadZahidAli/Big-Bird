using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
// Reference the Unity Analytics namespace
using UnityEngine.Analytics;
using UnityEngine.Advertisements; // Using the Unity Ads namespace.


using AppAdvisory.social;

public class GameOverManager : MonoBehaviour {

    public Text scoreText;
    public Text highScoreText;

    // public static int highScore;
    // public static int totalScore;
   // public static bool revive;
   // public static int temScore;
    //public static int count = 2;

    // Use this for initialization
    void Start () {
        Analytics.CustomEvent("gameOver", new Dictionary<string, object>
  {
    { "bird", Constants.selectedbird },
    { "coins", Constants.temScore }
  
  });


    }
    // Reference the Collections Generic namespace


  int totalPotions = 5;
int totalCoins = 100;


    void OnEnable()
    {
        //OnClickPosttoLeaderboard();
        scoreText.text = ScoreManagerScript.Score.ToString();

        // Debug.Log("total: "+ totalScore);

        //Constants.totalScore = PlayerPrefs.GetInt("totalScore");
        //Constants.highScore = PlayerPrefs.GetInt("highScore");
        Constants.LoadPrefs();


        if(ScoreManagerScript.Score > Constants.highScore)
        {
            Constants.highScore = ScoreManagerScript.Score;

            OnClickPosttoLeaderboard();

        }
        
        highScoreText.text = Constants.highScore.ToString();
        Constants.totalScore += ScoreManagerScript.Score;

        //PlayerPrefs.SetInt("highScore", Constants.highScore);
        //PlayerPrefs.SetInt("totalScore", Constants.totalScore);
        //PlayerPrefs.Save();
        Constants.SavePrefs();
        
        Invoke("Do",1f);

        Constants.count++;
    }

    void Do()
    {

        if (Constants.count % 10 == 0)
            UnityAdsManager.Instance.ShowVideoAd();
        else if (Constants.count % 3 == 0)
        {
            AdMobAds.Instance.showInterstitial();
        }
       else if(Constants.count % 2 == 0)
        {
            if (AdBuddizBinding.IsReadyToShowAd())
            {
                AdBuddizBinding.ShowAd();
            }
        }




    }





    public void OnClickPosttoLeaderboard()
    {
        // LeaderboardManager.ReportScore(Constants.highScore);
        //LeaderboardController.Instance.LogIn();
        //LeaderboardController.Instance.OnAddScoreToLeaderBorad();
        MainMenuManager.Instance.postScore("1", Constants.highScore);
    }

    //On Coins Revive
    public void OnClick50Coins()
    {
        //if(Constants.totalScore-10 >= 0)
        Constants.totalScore -= ScoreManagerScript.Score;
        Debug.Log("score:"+ Constants.totalScore);

        if (Constants.totalScore >= 10)
        {
            Constants.totalScore -= 10;
            // PlayerPrefs.SetInt("totalScore", Constants.totalScore);
            Constants.SavePrefs();
            Constants.revive = true;
            Constants.temScore = ScoreManagerScript.Score;
            //Debug.Log("score:"+temScore);
            MainMenuManager.Instance.RestartEvent();
            //PlayerPrefs.Save();
            
        }
        else
            Constants.totalScore += ScoreManagerScript.Score;


        Debug.Log("score:after " + Constants.totalScore);
        //PlayerPrefs.Save();

    }


    public void OnClickAd()
    {
       
        if (Advertisement.isInitialized || Advertisement.IsReady())
        {
            if (Constants.totalScore > 0)
            {
                Constants.totalScore -= ScoreManagerScript.Score;
                // PlayerPrefs.SetInt("totalScore", Constants.totalScore);
                Constants.SavePrefs();

                //Application.LoadLevel(Application.loadedLevel);
                UnityAdsManager.Instance.ShowRewardedVideoAd();

                //PlayerPrefs.Save();
            }

        }

    }










}
