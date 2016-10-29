using UnityEngine;
using System.Collections;

public class DestroyCoin : MonoBehaviour {



    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Flappy")
        {
            gameObject.SetActive(false);
        }
    }
}
