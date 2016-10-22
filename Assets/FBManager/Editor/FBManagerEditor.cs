using UnityEngine;
using System.Collections;
using UnityEditor;

public class FBManagerEditor : MonoBehaviour {

	#if UNITY_EDITOR
    
	[MenuItem("Facebook/FBManager/Documentation")]
	public static void OpenHelp()
	{
		string url = "https://goo.gl/ySh5xu";
		Application.OpenURL(url);
	}
	
	[MenuItem("Facebook/FBManager/About")]
	public static void ShowAbout()
	{
		EditorUtility.DisplayDialog("Facebook Leaderboard and Invite Version",
		                            "GameSlyce Facebook Leaderboard and Custom Invite Plugin's Current version is 3.2", "OK");
	}
	
	[MenuItem("Facebook/FBManager/Contact")]
	public static void ShowCredits()
	{
		EditorUtility.DisplayDialog("Contact Info",
		                            "Game Slyce: info.gameslyce@gmail.com", "OK");
	}
	#endif
}
