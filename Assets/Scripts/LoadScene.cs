﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoadScene : MonoBehaviour {

    public string loadScene;
    void LoadGame()
    {
        key = true;
       // SceneManager.LoadScene(loadScene);
    }
	// Use this for initialization
	void Start () {
        if (Constants.count % 2 == 0)
            AdMobAds.Instance.RequestInterstitial();

        Invoke("LoadGame",0f);
    }




    public string levelName;
    AsyncOperation async;

    private bool load = false;

   // [SerializeField]
   // private int scene=3;
    [SerializeField]
    private Text loadingText;
    bool key = false;

    // Updates once per frame
    void Update()
    {

        // If the player has pressed the space bar and a new scene is not loading yet...
        if (key && load == false)
        {

            // ...set the loadScene boolean to true to prevent loading a new scene more than once...
            load = true;

            // ...change the instruction text to read "Loading..."
            loadingText.text = "LOADING...";

            // ...and start a coroutine that will load the desired scene.
            StartCoroutine(LoadNewScene());

        }

        // If the new scene has started loading...
        if (load == true)
        {

            // ...then pulse the transparency of the loading text to let the player know that the computer is still working.
            loadingText.color = new Color(loadingText.color.r, loadingText.color.g, loadingText.color.b, Mathf.PingPong(Time.time, 1));

        }

    }


    // The coroutine runs on its own at the same time as Update() and takes an integer indicating which scene to load.
    IEnumerator LoadNewScene()
    {

        // This line waits for 3 seconds before executing the next line in the coroutine.
        // This line is only necessary for this demo. The scenes are so simple that they load too fast to read the "Loading..." text.
        yield return new WaitForSeconds(3);

        // Start an asynchronous operation to load the scene that was passed to the LoadNewScene coroutine.
        AsyncOperation async = Application.LoadLevelAsync(loadScene);

        // While the asynchronous operation to load the new scene is not yet complete, continue waiting until it's done.
        while (!async.isDone)
        {
            yield return null;
        }

    }
}
