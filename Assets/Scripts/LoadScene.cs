using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

    public string loadScene;
    void LoadGame()
    {
        SceneManager.LoadScene(loadScene);
    }
	// Use this for initialization
	void Start () {
        Invoke("LoadGame",4f);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
