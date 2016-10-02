using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PurchaserInterface : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public Text show;
    public void OnP1()
    {
        Purchaser.instance.Buyproduct1();
        show.text = "purchase";
    }

}
