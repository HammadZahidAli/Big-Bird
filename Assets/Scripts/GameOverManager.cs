using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameOverManager : MonoBehaviour {

    public Text scoreText;
    public Text highScoreText;
    
    public static int highScore;
    public static int totalScore;
    public static bool revive;
    public static int temScore;
	// Use this for initialization
	void Start () {
	    
	}

    void OnEnable()
    {

        scoreText.text = ScoreManagerScript.Score.ToString();
        

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
    }


    //On Coins Revive
    public void OnClick50Coins()
    {
        totalScore -= ScoreManagerScript.Score;
        if (totalScore >= 1)
        {
            totalScore -= 1;
            PlayerPrefs.SetInt("totalScore", totalScore);
            revive = true;
            temScore = ScoreManagerScript.Score;
            Debug.Log("score:"+temScore);
            MainMenuManager.Instance.RestartEvent();

            
        }
        else
            totalScore += ScoreManagerScript.Score;

    }


    public void OnClickAd()
    {
        totalScore -= ScoreManagerScript.Score;
        PlayerPrefs.SetInt("totalScore", totalScore);

        UnityAdsManager.Instance.ShowRewardedVideoAd();
        //Application.LoadLevel(Application.loadedLevel);
    }






}
