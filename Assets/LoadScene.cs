using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

    void LoadGame()
    {
        SceneManager.LoadScene("MainGame");
    }
	// Use this for initialization
	void Start () {
        Invoke("LoadGame",3f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
