using UnityEngine;
using System.Collections;

public class scroller : MonoBehaviour {


    Renderer renderer;
	// Use this for initialization
	void Start () {
        renderer = GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

        renderer.material.mainTextureOffset= (new Vector2(0,0.5f*Time.time));


    }
}
