﻿using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public GameObject[] birds;

    // Use this for initialization
    void Start() {
        for (int i = 0; i < birds.Length; i++)
            birds[i].SetActive(false);


        cameraZ = transform.position.z;


        if (Constants.selectedbird == 1)
        { birds[0].SetActive(true); Player = birds[0].transform; }
        else if (Constants.selectedbird == 2)
        { birds[1].SetActive(true); Player = birds[1].transform; }
        else if (Constants.selectedbird == 3)
        { birds[2].SetActive(true); Player = birds[2].transform; }
        else if (Constants.selectedbird == 4)
        { birds[3].SetActive(true); Player = birds[3].transform; }
        else if (Constants.selectedbird == 5)
        { birds[4].SetActive(true); Player = birds[4].transform; }
        else if (Constants.selectedbird == 6)
        { birds[5].SetActive(true); Player = birds[5].transform; }
        else if (Constants.selectedbird == 7)
        { birds[6].SetActive(true); Player = birds[6].transform; }
        else if (Constants.selectedbird == 8)
        { birds[7].SetActive(true); Player = birds[7].transform; }
        else if (Constants.selectedbird == 9)
        { birds[8].SetActive(true); Player = birds[8].transform; }
    }

    float cameraZ;


	void Update () {
        
        transform.position = new Vector3(Player.position.x + 0.65f, 0, cameraZ);
       
	}

    
    public Transform Player;
}
