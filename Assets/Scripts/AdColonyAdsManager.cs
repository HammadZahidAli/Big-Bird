using UnityEngine;
using System.Collections;
//using GoogleMobileAds.Api;
using UnityEngine.Advertisements; // Using the Unity Ads namespace.



public class AdColonyAdsManager : SingeltonBase<AdColonyAdsManager>
{

    void Start()
    {
        Initialize();

    }



    public void Initialize()
    {
        // Assign any AdColony Delegates before calling Configure
        AdColony.OnVideoFinished = this.OnVideoFinished;

        AdColony.OnV4VCResult = this.OnV4VCResult;
        

        // If you wish to use a the customID feature, you should call  that now.
        // Then, configure AdColony:
        AdColony.Configure
        (
          "version:1.0,store:google", // Arbitrary app version and Android app store declaration.
          "appdc2913c7cdb040d98b",   // ADC App ID from adcolony.com
          "v4vc251c95abb8644927ac", // video
          "vz9604946b51ff4e109f"
        // A zone ID from adcolony.com
        /*"vzf8fb4670a60e4a139d01b5", // Any number of additional Zone IDS
        "vz1fd5a8b2bf6841a0a4b826"*/
        );
    }

    string zoneIDForReward = "v4vc251c95abb8644927ac";
    // When a video is available, you may choose to play it in any fashion you like.
    // Generally you will play them automatically during breaks in your game,
    // or in response to a user action like clicking a button.
    // Below is a method that could be called, or attached to a GUI action.
    public void PlayV4VCAd(string zoneIDForReward= "v4vc251c95abb8644927ac", bool prePopup=false, bool postPopup=true)
    {
        // Check to see if a video for V4VC is available in the zone.
        if (AdColony.IsV4VCAvailable(zoneIDForReward))
        {
            Debug.Log("Play AdColony V4VC Ad");
            // The AdColony class exposes two methods for showing V4VC Ads.
            // ---------------------------------------
            // The first `ShowV4VC`, plays a V4VC Ad and, optionally, displays
            // a popup when the video is finished.
            // ---------------------------------------
            // The second is `OfferV4VC`, which popups a confirmation before
            // playing the ad and, optionally, displays popup when the video 
            // is finished.

            // Call one of the V4VC Video methods:
            // Note that you should also pause your game here (audio, etc.) AdColony will not
            // pause your app for you.
            if (prePopup) AdColony.OfferV4VC(postPopup, zoneIDForReward);
            else AdColony.ShowV4VC(postPopup, zoneIDForReward);

            ////if (false)
            //AdColony.OfferV4VC(true, zoneIDForReward);
            ////else 
            ////AdColony.ShowV4VC(true, zoneIDForReward);
        }
        else
        {
            Debug.Log("V4VC Ad Not Available");
        }
    }




 

    // The V4VCResult Delegate assigned in Initialize -- AdColony calls this after confirming V4VC transactions with your server
    // success - true: transaction completed, virtual currency awarded by your server - false: transaction failed, no virtual currency awarded
    // name - The name of your virtual currency, defined in your AdColony account
    // amount - The amount of virtual currency awarded for watching the video, defined in your AdColony account
    private void OnV4VCResult(bool success, string name, int amount)
    {
        if (success)
        {
            Debug.Log("V4VC SUCCESS: name = " + name + ", amount = " + amount);
            //TimerManager.RewardTime = true;
            Constants.coinsAdsbool = false;
            Constants.totalScore += 20;

            //PlayerPrefs.SetInt("totalscore", Constants.totalScore);
            //PlayerPrefs.Save();
            Constants.SavePrefs();
        }
        else
        {
            Debug.LogWarning("V4VC FAILED!");
        }
    }






    string zoneID = "vz9d141739db9c4e4db4";
    private void OnVideoFinished(bool ad_was_shown)
    {
        Debug.Log("On Video Finished");
        // Resume your app here.
    }


    // When a video is available, you may choose to play it in any fashion you like.
    // Generally you will play them automatically during breaks in your game,
    // or in response to a user action like clicking a button.
    // Below is a method that could be called, or attached to a GUI action.
    public void PlayAVideo()
    {
        // Check to see if a video is available in the zone.
        if (AdColony.IsVideoAvailable(zoneID))
        {
            Debug.Log("Play AdColony Video");
            // Call AdColony.ShowVideoAd with that zone to play an interstitial video.
            // Note that you should also pause your game here (audio, etc.) AdColony will not
            // pause your app for you.
            AdColony.ShowVideoAd(zoneID);
        }
        else
        {
            Debug.Log("Video Not Available");
        }
    }






  
 }