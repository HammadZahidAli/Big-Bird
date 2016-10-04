using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenuManager : SingeltonBase<MainMenuManager> {
	
	public Animator contentPanel;
	public GameObject MainMenuPanel,StorePanel, GameOverPanel,soundObject;
	public Sprite mute,sound;
	
	// Use this for initialization
	
	void Start () {
		MenuHome ();
		//gameOver ();
	}
	
	/// <summary>
	/// Menus the home.
	/// </summary>
	public void MenuHome () {
		
		//iTween.MoveTo ( MainMenuPanel, iTween.Hash(
		//	"position", new Vector3 (0, 0, 0), 
			 
		//	"delay", 0.3f,
		//	"easetype",	iTween.EaseType.spring,
		//	"time", 1.0f));
	}
	
	/// <summary>
	/// Menu home hide.
	/// </summary>
	public void MenuHomeHide() {
		//iTween.MoveTo ( MainMenuPanel, iTween.Hash(
		//	"position", new Vector3 (-844, 0, 0), 
		//	"islocal", true, 
		//	"delay", 0.5f,
		//	"easetype",	iTween.EaseType.spring,
		//	"time", 1.0f));
	}
	
	/// <summary>
	/// Share menu toggle.
	/// </summary>
	public void ShareMenuToggle() {
		
		//int isHidden = contentPanel.GetInteger("SlideValue");
		
		//if(isHidden == 1) {
		//	contentPanel.SetInteger("SlideValue", 2);
			
		//} else {
		//	contentPanel.SetInteger("SlideValue", 1);
		//}
		
	}
	
	/// <summary>
	/// Home store event.
	/// </summary>
	public void HomeStoreEvent(){
		//iTween.MoveTo ( StorePanel, iTween.Hash(
		//	"position", new Vector3 (-844, 0, 0), 
		//	"islocal", true, 
		//	"easetype",	iTween.EaseType.spring,
		//	"time", 1.0f));
		
		StartCoroutine (MenuStoreHide(0f));
	}
	
	
	
	/// <summary>
	/// Menu store hide.
	/// </summary>
	/// <returns>The store hide.</returns>
	/// <param name="waitTime">Wait time.</param>
	IEnumerator MenuStoreHide(float waitTime) {
		
		yield return new WaitForSeconds(waitTime);
		
		MainMenuPanel.SetActive(true);
		StorePanel.SetActive(false);
		
		MenuHome ();
	}
	
	/// <summary>
	/// Store button event.
	/// </summary>
	public void StoreBtnEvent(){

		//MenuHomeHide();
		
		//iTween.MoveTo ( StorePanel, iTween.Hash(
		//	"position", new Vector3 (0, 0, 0), 
		//	"islocal", true,
		//	"delay", 0.0f,
		//	"easetype",	iTween.EaseType.spring, 
		//	"time", 1.0f));
		
		StartCoroutine (MenuHomeHide(0f));
		
		
	}
	
	/// <summary>
	/// Menu home hide.
	/// </summary>
	/// <returns>The home hide.</returns>
	/// <param name="waitTime">Wait time.</param>
	IEnumerator MenuHomeHide(float waitTime) {
		
		yield return new WaitForSeconds(waitTime);
		
		MainMenuPanel.SetActive(false);
		StorePanel.SetActive(true);
	}
	
	public void onPlay () {

		//UIManager.Instance.OnGamePlay();
	}
	/// <summary>
	/// Games the over.
	/// </summary>
	public void gameOver() {

		//GameOverPanel.GetComponent<GameOverManager> ().UpdateScore ();
		GameOverPanel.SetActive(true);
		
		//iTween.MoveTo ( GameOverPanel, iTween.Hash(
		//	"position", new Vector3 (0, 0, 0), 
		//	"islocal", true, 
		//	"delay", 0.0f,
		//	"easetype",	iTween.EaseType.spring,
		//	"time", 1.0f));
		
	}
	/// <summary>
	/// Games the over home event.
	/// </summary>
	public void GameOverHomeEvent(){
        GameStateManager.GameState = GameState.Intro;
        GameOverPanel.SetActive(false);

        MainMenuPanel.SetActive(true);

        SceneManager.LoadScene ("MenuScene");

//		Application.LoadLevel (1);
		//iTween.MoveTo ( GameOverPanel, iTween.Hash(
		//	"position", new Vector3 (-844, 0, 0), 
		//	"islocal", true, 
		//	"delay", 0.5f,
		//	"easetype",	iTween.EaseType.spring,
		//	"time", 1.0f));
		
		
		
		StartCoroutine(MoveFromGameOver(0.0f));
		
	}
	
	IEnumerator MoveFromGameOver(float waitTime){
		yield return new WaitForSeconds(waitTime);
		
		//iTween.MoveTo ( MainMenuPanel, iTween.Hash(
		//	"position", new Vector3 (0, 0, 0), 
		//	"islocal", true, 
		//	"delay", 0.0f,
		//	"easetype",	iTween.EaseType.spring,
		//	"time", 1.0f));
		
		//StartCoroutine(HomeScene(1.0f));
	}
	
	
	IEnumerator HomeScene(float waitTime){
		yield return new WaitForSeconds(waitTime);
		
	}
	/// <summary>
	/// Restarts the event.
	/// </summary>
	public void RestartEvent(){
        GameStateManager.GameState = GameState.Intro;
        //iTween.MoveTo ( GameOverPanel, iTween.Hash(
        //	"position", new Vector3 (-844, 0, 0), 
        //	"islocal", true, 
        //	"delay", 0.0f,
        //	"easetype",	iTween.EaseType.spring,
        //	"time", 1.0f));

        StartCoroutine(MenuGameOverHide(0));
	}
	
	IEnumerator MenuGameOverHide(float waitTime) {
		
		yield return new WaitForSeconds(waitTime);
		GameOverPanel.SetActive(false);
		//SceneManager.LoadScene (1);
		
		Application.LoadLevel (1);
		
	}



	/// <summary>
	/// Games the play event.
	/// </summary>
	/// 
	/// 
	/// 
	public void GamePlayEvent(){
        GetComponent<FadeIn>().fadeIn();
        //MainMenuPanel.SetActive(false);
		//iTween.MoveTo ( MainMenuPanel, iTween.Hash(
		//	"position", new Vector3 (-844, 0, 0), 
			
		//	"delay", 0.5f,
		//	"easetype",	iTween.EaseType.spring,
		//	"time", 1.0f));
		StartCoroutine(OnGamePlay(1f));
	}
	IEnumerator OnGamePlay(float waitTime){
		yield return new WaitForSeconds(waitTime);
        //SceneManager.LoadScene (1);
        MainMenuPanel.SetActive(false);
        Application.LoadLevel (1);

	}
	/// <summary>
	/// Sound state.
	/// </summary>

	
	public void FacebookShare(){

	}
	public void TwitterShare(){
	}
	public void ShowLeaderBoard(){


	}

	public void OnRateUsClick()
	{
		Application.OpenURL ("");
		
	}

	public void onIAP(int pType) {
		
		
		switch (pType) {
			
		case 0:
			//StoreManager.Instance.PurchasePackage (CentralVariables.PACKAGE_REMOVEADS);
			break;
		case 1:
			//StoreManager.Instance.PurchasePackage (CentralVariables.PACKAGE_COINS_PKG1);
			break;
		case 2:
			//StoreManager.Instance.PurchasePackage (CentralVariables.PACKAGE_COINS_PKG2);
			break;
		case 3:
			//StoreManager.Instance.PurchasePackage (CentralVariables.PACKAGE_COINS_PKG3);
			//StoreManager.Instance.PurchasePackage (CentralVariables.PACKAGE_REMOVEADS);
			break;
		case 4:
			//StoreManager.Instance.RestoreCompletedTransactions();
			break;
		}
		
	}

}
