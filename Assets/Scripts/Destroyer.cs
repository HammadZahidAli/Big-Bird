using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour {

 

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Cloud")
        {
            // Destroy(col.gameObject.transform.parent.gameObject); //free up some memory

            col.gameObject.transform.root.gameObject.SetActive(false);

        }
    }
}
