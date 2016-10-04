using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour {


	public  GameObject fade;
	public float transitionTime=0.5f;

	void Start () {

		fadeOut ();
	}
	void fadeOut()
	{

        fade.SetActive(true);
        fade.GetComponent<Image>().canvasRenderer.SetAlpha(1.0f);
        fade.GetComponent<Image>().CrossFadeAlpha(0.0f, transitionTime, false);
  //      Debug.Log ("fade out");
		//fade.SetActive(true);
		////fade.GetComponent<Image> ().CrossFadeAlpha (0f,0,true);
		//fade.GetComponent<Image> ().CrossFadeAlpha (1f,0,true);
		////fade.GetComponent<Image>().canvasRenderer.SetAlpha(0);
		//fade.GetComponent<Image> ().CrossFadeAlpha (0f,transitionTime,true);
		Invoke ("wait", transitionTime);
	}

	void wait()
	{
		fade.SetActive (false);

	}


}
