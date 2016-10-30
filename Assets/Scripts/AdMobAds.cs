using UnityEngine;
using System.Collections;

using GoogleMobileAds.Api;


public class AdMobAds : SingeltonBase<AdMobAds>
{
    InterstitialAd interstitial;

#if UNITY_EDITOR
    string adUnitId = "ca-app-pub-9530927484515291/5720723761";
#elif UNITY_ANDROID
    string adUnitId = "ca-app-pub-9530927484515291/5720723761";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-9530927484515291/5720723761";
#else
        string adUnitId = "ca-app-pub-9530927484515291/5720723761";
#endif



    void Start()
    {
        RequestInterstitial();
    }

public void RequestInterstitial()
{


       // Initialize an InterstitialAd.
       interstitial = new InterstitialAd(adUnitId);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();


        // Load the interstitial with the request.
        interstitial.LoadAd(request);
}


public void showInterstitial()
    {
        if (interstitial.IsLoaded()) { 
            Debug.Log("showing...");
            interstitial.Show();
        }
        else
             Debug.Log("not loaded...");;

    }


}
