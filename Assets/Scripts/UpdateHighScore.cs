using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using AppAdvisory.social;

public class UpdateHighScore : MonoBehaviour {

    public Text highScoreText;
    public Text totalScoreText;

    void OnEnable()
    {
        // PlayerPrefs.DeleteAll();

        //PlayerPrefs.Save();
        AdBuddizRewardedVideoManager.didComplete += DidComplete;

        highScoreText.text = "High Score : " + GameOverManager.highScore;
        totalScoreText.text = "Total Score : " + GameOverManager.totalScore;

    }

    void Start()
    {



        currentSoundState = PlayerPrefs.GetInt("currentSoundState");
        if (currentSoundState == 1)
            soundObject.GetComponent<Image>().sprite = on;
        else
            soundObject.GetComponent<Image>().sprite = off;
    }

    void Update()
    {
        if(totalScoreText)
        {
            totalScoreText.text = "Total Score : " + GameOverManager.totalScore.ToString();
        }
       
    }

    public void OnClickShowLeaderBoard()
    {
        LeaderboardManager.ShowLeaderboardUI();
    }

    public void OnClickReportLeaderBoard()
    {
        LeaderboardManager.ReportScore(20);
    }


    public GameObject FBCanvas;
    public void OnClickFBLeaderboard()
    {
        FBCanvas = GameObject.FindGameObjectWithTag("FBCanvas");
        //FBCanvas.SetActive(true);
        FBCanvas.GetComponent<Canvas>().enabled = true;
    }


    public Sprite on,off;
    public GameObject soundObject;
    public static int currentSoundState=1;
    public void OnClickSound()
    {
       
        if(currentSoundState == 1)
        {
            soundObject.GetComponent<Image>().sprite = off;
            currentSoundState = 0;
            SoundManager.Instance.musicSource.mute = true;
            SoundManager.Instance.audioSource.mute = true;
            SoundManager.Instance.playerAudioSource.mute = true;
            PlayerPrefs.SetInt("currentSoundState", 0);
            PlayerPrefs.Save();
        }
        else
        {
            soundObject.GetComponent<Image>().sprite = on;
            currentSoundState = 1;
            SoundManager.Instance.musicSource.mute = false;
            SoundManager.Instance.audioSource.mute = false;
            SoundManager.Instance.playerAudioSource.mute = false;
            PlayerPrefs.SetInt("currentSoundState", 1);
            PlayerPrefs.Save();
        }

    }


    // Adbuddiz Code for Rewarded Videos

    public void OnClickAdbuddizRewardedVideo()
    {
        AdBuddizBinding.RewardedVideo.Show();
        
        //AdColonyAdsManager.Instance.PlayV4VCAd();

    }


    void OnDisable()
    { // unregister as a listener
        AdBuddizRewardedVideoManager.didComplete -= DidComplete;
    }

    void DidComplete()
    {
        // Give the reward
        ShopManager.coinsAdsbool = false;
        GameOverManager.totalScore = PlayerPrefs.GetInt("totalscore") + 50;
        Debug.Log("total" + GameOverManager.totalScore);
        PlayerPrefs.SetInt("totalscore", GameOverManager.totalScore);
        PlayerPrefs.Save();

    }

}
