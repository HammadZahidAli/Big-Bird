using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using AppAdvisory.social;

public class PostScore : MonoBehaviour 
{
	public int score = 10;
    
	void Awake()
	{
        Debug.Log("highScore: "+ Constants.highScore);
		GetComponent<Button>().onClick.AddListener(OnClicked);
	}

	void OnClicked()
	{
        Constants.LoadPrefs();
		LeaderboardManager.ReportScore(Constants.highScore);
	}
}
