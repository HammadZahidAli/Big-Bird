using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpdateHighScore : MonoBehaviour {

    public Text highScoreText;
    public Text totalScoreText;

    void OnEnable()
    {

        highScoreText.text = "High Score : " + PlayerPrefs.GetInt("highScore").ToString();
        totalScoreText.text = "Total Score : " + PlayerPrefs.GetInt("totalScore").ToString();
    }

}
