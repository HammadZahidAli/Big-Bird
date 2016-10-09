using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class GameOverManager : MonoBehaviour {

    public Text scoreText;
    public Text highScoreText;
    
    public static int highScore;
    public static int totalScore;

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

        PlayerPrefs.SetInt("highScore", ScoreManagerScript.Score);
        PlayerPrefs.SetInt("totalScore", totalScore);
    }


    //On Coins Revive
    public void OnClick50Coins()
    {
        totalScore -= ScoreManagerScript.Score;
        PlayerPrefs.SetInt("totalScore", totalScore);
        Application.LoadLevel(Application.loadedLevel);
    }


    public void OnClickAd()
    {
        totalScore -= ScoreManagerScript.Score;
        PlayerPrefs.SetInt("totalScore", totalScore);

        UnityAdsManager.Instance.ShowRewardedVideoAd();
        //Application.LoadLevel(Application.loadedLevel);
    }






}
