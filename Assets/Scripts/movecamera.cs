﻿using UnityEngine;
using System.Collections;

public class movecamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.up * Time.deltaTime);
	}
}