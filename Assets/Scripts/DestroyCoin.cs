using UnityEngine;
using System.Collections;

public class DestroyCoin : MonoBehaviour {



    void OnTriggerEnter2D(Collider2D coll)
    {
       // Debug.Log("coming");
        if (coll.gameObject.tag == "Flappy")
        {

            gameObject.SetActive(false);
        }
    }
}
