using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpdateScoreFB : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.gameObject.GetComponent<Text>().text += Constants.highScore;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
