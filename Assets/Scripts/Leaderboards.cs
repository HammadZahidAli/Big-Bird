using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using GameSparks.Api.Requests;

public class Leaderboards : MonoBehaviour {

    public GameObject leaderboardEntryPrefab;
   // public GameObject layout;
    public List<GameObject> entries = new List<GameObject>();
    public GameObject[] items;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void GetLeaderboard()
    {
        for (int i = 0; i < entries.Count; i++)
        {
            //Destroy(entries[i]);
        }



        entries.Clear();

        new LeaderboardDataRequest_highScoreLeaderboard().SetEntryCount(10).Send((response) =>
        {
            int i = 0;
            foreach(var entry in response.Data)
            {
                items[i].GetComponent<LeaderboardEntry>().rankText.text = entry.Rank.ToString();
                items[i].GetComponent<LeaderboardEntry>().userNameText.text = entry.UserName.ToString();
                items[i].GetComponent<LeaderboardEntry>().scoreText.text = entry.GetNumberValue("score").ToString();
                items[i].GetComponent<LeaderboardEntry>().facebookID = entry.ExternalIds.GetString("FB");
                items[i].GetComponent<LeaderboardEntry>().GetPic();

                entries.Add(items[i]);
                i++;
            }
        });
    }
}
