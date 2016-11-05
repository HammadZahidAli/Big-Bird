using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class LeaderboardEntry : MonoBehaviour {


    public Text rankText, userNameText, scoreText;
    public string rank, userName, score;


	// Use this for initialization
	void Start () {
        rankText.text = rank;
        userNameText.text = userName;
        scoreText.text = score;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
