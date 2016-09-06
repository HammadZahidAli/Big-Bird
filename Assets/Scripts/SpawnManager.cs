using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
	
	}

    public GameObject[] Spawners; 

    int counter = 0;
    float temp;
	// Update is called once per frame
	void Update () {

        temp += Time.deltaTime;
        counter = (int)temp;
       
 


	}
}
