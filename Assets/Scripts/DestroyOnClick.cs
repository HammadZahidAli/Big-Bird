using UnityEngine;
using System.Collections;

public class DestroyOnClick : MonoBehaviour {

    public GameObject Parent;
	public void OnClick()
    {
        Parent.SetActive(false);

    }
}
