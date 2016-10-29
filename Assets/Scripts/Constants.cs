using UnityEngine;
using System.Collections;

public class Constants  {

    public static int currentSoundState = 1;
    public static int totalScore;
    public static int highScore;


    //Birds
    public static int selectedbird = 1;


    //coins
    public static bool coinsAdsbool = false;


    public static bool revive;
    public static int temScore;
    public static int count = 2;


    public static void SavePrefs()
    {
        PlayerPrefs.SetInt("highScore", Constants.highScore);
        PlayerPrefs.SetInt("totalScore", Constants.totalScore);


        PlayerPrefs.Save();
    }


    public static void LoadPrefs()
    {
        Constants.currentSoundState = PlayerPrefs.GetInt("currentSoundState");
        Constants.totalScore = PlayerPrefs.GetInt("totalScore");
        Constants.highScore = PlayerPrefs.GetInt("highScore");



    }

}
