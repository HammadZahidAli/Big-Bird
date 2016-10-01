using UnityEngine;
using System.Collections;

public class PurchaserInterface : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void OnP1()
    {
        Purchaser.instance.Buyproduct1();
    }

}
