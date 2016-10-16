using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements; // Using the Unity Ads namespace.


public class UnityAdsManager : SingeltonBase<UnityAdsManager> {

    public string gameId; // Set this value from the inspector.
#if !UNITY_ADS // If the Ads service is not enabled...
	
	public bool enableTestMode = true;
#endif

    IEnumerator Start ()
	{
		#if !UNITY_ADS // If the Ads service is not enabled...
		if (Advertisement.isSupported) { // If runtime platform is supported...
		Advertisement.Initialize(gameId, enableTestMode); // ...initialize.
		Debug.Log("UnityAds:: Initializing");
		}
		#endif

		// Wait until Unity Ads is initialized,
		//  and the default ad placement is ready.
		while (!Advertisement.isInitialized || !Advertisement.IsReady()) {
			Debug.Log("UnityAds:: waiting");
			yield return new WaitForSeconds(0.5f);
		}

	}

	public string VideozoneId;
	public void ShowVideoAd()
	{
		// Show the default ad placement.
		if (Advertisement.IsReady (VideozoneId)) {
			Debug.Log ("Unity Ads video Showing ");

			ShowOptions options = new ShowOptions ();
			options.resultCallback = HandleShowResult;
			//options.pause = true;

			Advertisement.Show (VideozoneId, options);
		} else {
			Debug.Log ("Unity video Ads not available");
		}
	}


	/*
	 * For Reward Video Ads
	 */
	public string RewardzoneId;
	public int rewardQty = 250;
	public void ShowRewardedVideoAd()
	{
		if (string.IsNullOrEmpty (RewardzoneId)) RewardzoneId = null;

		if (Advertisement.IsReady(RewardzoneId))
			{
				Debug.Log("Unity Ads Showing ");

				ShowOptions options = new ShowOptions();
				options.resultCallback = HandleShowResult;
				//options.pause = true;

				Advertisement.Show(RewardzoneId,options);
			}
			else 
			{
				Debug.LogWarning(string.Format("Unable to show ad. The ad placement zone {0} is not ready.",
				object.ReferenceEquals(RewardzoneId,null) ? "default" : RewardzoneId));
			}	
	}

    public GameObject successDialog;
	public GameObject FailureDialog;
	private void HandleShowResult (ShowResult result)
	{
		switch (result)
		{
		case ShowResult.Finished:
			Debug.Log ("Video completed. User rewarded " + rewardQty + " credits.");
                if (ShopManager.coinsAdsbool)
                {
                    ShopManager.coinsAdsbool = false;
                    GameOverManager.totalScore = PlayerPrefs.GetInt("totalscore") + 50;
                    Debug.Log("total" + GameOverManager.totalScore);
                    PlayerPrefs.SetInt("totalscore",GameOverManager.totalScore);
                    PlayerPrefs.Save();
                    Instantiate(successDialog,successDialog.transform.position,Quaternion.identity);
                    return;
                }
                else
                {
                    Debug.Log("coming");
                    GameOverManager.revive = true;
                    GameOverManager.temScore = ScoreManagerScript.Score;
                    Debug.Log("score:" + GameOverManager.temScore);
                    MainMenuManager.Instance.RestartEvent();

                }
               
                break;
		case ShowResult.Skipped:
			Debug.LogWarning ("Video was skipped.");
			break;
		case ShowResult.Failed:
                Debug.LogWarning("Video failed.");
                if (ShopManager.coinsAdsbool)
                {
                    ShopManager.coinsAdsbool = false;
                    Instantiate(FailureDialog, FailureDialog.transform.position, Quaternion.identity);
                }
                else
                {
                    GameOverManager.totalScore += ScoreManagerScript.Score;
                    PlayerPrefs.SetInt("totalScore", GameOverManager.totalScore);
                    Instantiate(FailureDialog, FailureDialog.transform.position, Quaternion.identity);
                }
                Debug.LogError ("Video failed to show.");
			break;
		}
	}




}
