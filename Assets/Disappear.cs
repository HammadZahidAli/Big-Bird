using UnityEngine;
using System.Collections;

public class Disappear : MonoBehaviour {

    public float time;

	// Use this for initialization
	void Start () {
        Invoke("Hide", time);
	}

    void Hide()
    {
        this.gameObject.SetActive(false);
    }
}
