using UnityEngine;
using System.Collections;

public class PixelsPerfectCamera : MonoBehaviour {

	public static float pixelperunit = 1f;
	public static float scale = 1f;

	public Vector2 nativeResolution = new Vector2(240,160);

	// Use this for initialization
	void Awake () {
		var camera = GetComponent<Camera> ();

		if (camera.orthographic) {
			scale = Screen.height / nativeResolution.y;
			pixelperunit *= scale;

			camera.orthographicSize = (Screen.height/2f)/pixelperunit;

		}


	}

}
