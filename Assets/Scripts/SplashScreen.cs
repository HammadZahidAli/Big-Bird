using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SplashScreen : MonoBehaviour {

    public Image splashImage;
    public string LoadScene= "MenuScene";

    IEnumerator Start()
    {
        splashImage.canvasRenderer.SetAlpha(0.1f);
        fadein();
        yield return new WaitForSeconds(2.5f);
        fadeout();
        yield return new WaitForSeconds(2.5f);

        SceneManager.LoadScene(LoadScene);

    }


    void fadein()
    {
        splashImage.CrossFadeAlpha(1f,1.5f,false);
    }
    void fadeout()
    {
        splashImage.CrossFadeAlpha(0f, 2.5f, false);

    }
}
