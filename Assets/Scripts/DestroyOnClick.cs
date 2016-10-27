using UnityEngine;
using System.Collections;

public class DestroyOnClick : MonoBehaviour {

    public GameObject Parent;
	public void OnClick()
    {
        Parent.SetActive(false);

    }

    public void OnClickCanvas()
    {
        Parent.GetComponent<Canvas>().enabled = false;
    }
}
