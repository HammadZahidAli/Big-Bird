using UnityEngine;
using System.Collections;

public class HideAfter : MonoBehaviour {
    public float time;
    // Use this for initialization
    void Start() {
        Invoke("Hide",time);
    }


    void Hide()
        {
        gameObject.SetActive(false);
        }

    // Update is called once per frame
    void Update () {
	
	}
}
