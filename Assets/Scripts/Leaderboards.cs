using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using GameSparks.Api.Requests;

public class Leaderboards : MonoBehaviour {

    public GameObject leaderboardEntryPrefab;
   // public GameObject layout;
    public List<GameObject> entries = new List<GameObject>();
    public GameObject[] items;

    public GameObject prefabEntry;
    public GameObject MaskPanelImage;

    // Use this for initialization


    void Start()
    {
    
    }
    public void GetLeaderboard()
    {
        for (int i = 0; i < entries.Count; i++)
        {
            if(entries[i]!=null)
            Destroy(entries[i]);
        }



        entries.Clear();

        //highScoreLeaderboard
        new LeaderboardDataRequest_highScoreLeaderboard().SetEntryCount(30).Send((response) =>
        {
            int i = 0;
            foreach(var entry in response.Data)
            {

                GameObject entryObj = Instantiate(prefabEntry) as GameObject;
                entryObj.transform.SetParent(MaskPanelImage.transform, false);
                LeaderboardEntry comp = entryObj.GetComponent<LeaderboardEntry>();

                comp.rank = entry.Rank.ToString();
                comp.userName = entry.UserName.ToString();
                comp.score = entry.GetNumberValue("score").ToString();
                comp.facebookID = entry.ExternalIds.GetString("FB");

                comp.SetData(comp.rank, comp.userName, comp.score);
                comp.GetPic();


                entries.Add(entryObj);
                i++;
            }
        });
    }
}
