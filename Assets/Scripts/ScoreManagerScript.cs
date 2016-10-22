using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ScoreManagerScript : MonoBehaviour {

    public static int Score { get; set; }

	// Use this for initialization
	void Start () {
       // (Tens.gameObject as GameObject).SetActive(false);
       // (Hundreds.gameObject as GameObject).SetActive(false);

	}

    public Text levelText;
    void Wait()
    {
        levelText.GetComponent<Text>().text = "";
    }
	// Update is called once per frame
	void Update () {

        if (previousScore != Score) //save perf from non needed calculations
        {
            ScoreText.GetComponent<Text>().text = Score.ToString();

            if (Score % 10 == 0 && Score != 0)
            {
                levelText.GetComponent<Text>().text = "Level Up ++";
                Score += 2;
                Invoke("Wait",2f);

            }
               

            //if (Score < 10)
            //{
            //    //just draw units
            //    //Units.sprite = numberSprites[Score];
            //}
            //else if(Score >= 10 && Score < 100)
            //{
            //   // (Tens.gameObject as GameObject).SetActive(true);
            //    //Tens.sprite = numberSprites[Score / 10];
            //   // Units.sprite = numberSprites[Score % 10];
            //}
            //else if(Score >= 100)
            //{
            //   // (Hundreds.gameObject as GameObject).SetActive(true);
            //   // Hundreds.sprite = numberSprites[Score / 100];
            //   // int rest = Score % 100;
            //   // Tens.sprite = numberSprites[rest / 10];
            //  //  Units.sprite = numberSprites[rest % 10];
            //}
        }

	}

    public GameObject ScoreText;
    int previousScore = -1;
    public Sprite[] numberSprites;
    public SpriteRenderer Units, Tens, Hundreds;
}
