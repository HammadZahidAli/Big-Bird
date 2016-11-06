using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class LeaderboardEntry : MonoBehaviour {


    public Text rankText, userNameText, scoreText;
    public string rank, userName, score, facebookID = "";


    public Image profilePic;



    // Use this for initialization
    void Start () {
        profilePic = GetComponentInChildren<Image>();
        rankText.text = rank;
        userNameText.text = userName;
        scoreText.text = score;

        if (facebookID != "")
        {
            StartCoroutine(getFBPicture());
        }
    }
	
    public void GetPic()
    {
        StartCoroutine(getFBPicture());
    }

       public IEnumerator getFBPicture()
        {
                var www = new WWW("http://graph.facebook.com/" + facebookID + "/picture?type=square");

                 yield return www;
 
                //make sure the dimensions of the new texture match what we set                 //up in the Leaderboard Entry prefab
                Texture2D tempPic = new Texture2D(40, 40);

                www.LoadImageIntoTexture(tempPic);

        RawImage sr = GetComponentInChildren<RawImage>();
        sr.texture = tempPic;
        sr.color = Color.white;
    }


}
