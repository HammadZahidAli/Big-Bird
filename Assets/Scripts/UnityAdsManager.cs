using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements; // Using the Unity Ads namespace.


public class UnityAdsManager : SingeltonBase<UnityAdsManager> {


	#if !UNITY_ADS // If the Ads service is not enabled...
	public string gameId; // Set this value from the inspector.
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

	public GameObject FailureDialog;
	private void HandleShowResult (ShowResult result)
	{
		switch (result)
		{
		case ShowResult.Finished:
			Debug.Log ("Video completed. User rewarded " + rewardQty + " credits.");
			//CentralVariables.SeenRewardedAd = true;
			//if (CentralVariables.DoubleCoins) {
			//	CentralVariables.PlayerCurrentCoins = CentralVariables.PlayerCurrentCoins * 2;
			//	CentralVariables.SaveToFile ();
			//}

			break;
		case ShowResult.Skipped:
			Debug.LogWarning ("Video was skipped.");
			break;
		case ShowResult.Failed:
			
			//if (CentralVariables.applyforReward || CentralVariables.DoubleCoins) {
			//	Instantiate (FailureDialog, FailureDialog.transform.position, Quaternion.identity);
			//	CentralVariables.applyforReward = false;
			//	CentralVariables.DoubleCoins = false;
			//}
				
			Debug.LogError ("Video failed to show.");
			break;
		}
	}




}
