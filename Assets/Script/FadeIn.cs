using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour {

	// Use this for initialization

    void Start()
    {
        
    }
    void Reset()
    {
        fade.SetActive(false);
    }

	public  GameObject fade;
	public float transitionTime=2f;

	public void fadeIn()
	{
        fade.SetActive(true);
        fade.GetComponent<Image>().canvasRenderer.SetAlpha(0.01f);
        fade.GetComponent<Image>().CrossFadeAlpha(1.0f, transitionTime, false);



        Invoke("Reset", 1f);
		//StartCoroutine (FadeOut());
	}


}
