using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


    class PipeDestroyerScript : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D col)
        {
        Debug.Log("clou...");
        if (col.tag == "Pipe" || col.tag == "Pipeblank")
                Destroy(col.gameObject.transform.parent.gameObject); //free up some memory

            if(col.tag == "Cloud")
            {
                 Debug.Log("clou");
                Destroy(col.gameObject.transform.parent.gameObject); //free up some memory

            }
        }

}

