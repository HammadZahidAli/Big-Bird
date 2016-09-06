using UnityEngine;
using System.Collections;

public class TilesBG : MonoBehaviour {
	
	public int textureSize = 32;
	public bool scaleHorizontially = true;
	public bool scaleVertically = true;



	// Use this for initialization
	void Start () {
		
		var newWidth = !scaleHorizontially ? 1 : Mathf.Ceil (Screen.width / (textureSize * 3.2f));
		var newHeight = !scaleVertically ? 1 : Mathf.Ceil (Screen.height / (textureSize *3.2f));
		
		transform.localScale = new Vector3 (newWidth * textureSize, newHeight * textureSize, 1);
		
		GetComponent<Renderer> ().material.mainTextureScale = new Vector3 (newWidth, newHeight, 1);
	}
	
}
