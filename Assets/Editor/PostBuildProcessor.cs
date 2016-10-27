#if UNITY_5
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using System.Collections;

using System.IO;

public class PostBuildProcessor : MonoBehaviour
{
	#if UNITY_CLOUD_BUILD
	public static void OnPostprocessBuildiOS (string exportPath)
	{
		Debug.Log("OnPostprocessBuildiOS");
		ProcessPostBuild(BuildTarget.iPhone,exportPath);
	}
	#endif

	[PostProcessBuild]
	public static void OnPostprocessBuild (BuildTarget buildTarget, string path)
	{
		//if (buildTarget != BuildTarget.iPhone) { // For Unity < 5
		if (buildTarget != BuildTarget.iOS) {
			Debug.LogWarning("Target is not iOS. AdColonyPostProcess will not run");
			return;
    }

		#if !UNITY_CLOUD_BUILD
    Debug.Log ("OnPostprocessBuild");
    ProcessPostBuild (buildTarget, path);
		#endif
	}

    private static void ProcessPostBuild(BuildTarget buildTarget, string path)
    {
    }
}
#endif
