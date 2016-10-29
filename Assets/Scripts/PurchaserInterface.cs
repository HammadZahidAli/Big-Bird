using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PurchaserInterface : MonoBehaviour {



    public Text show;
    public void OnP1()
    {
        Purchaser.instance.Buyproduct1();
       // show.text = "purchase1";
    }

    public void OnP2()
    {
        Purchaser.instance.Buyproduct2();
      //  show.text = "purchase2";
    }

    public void OnP3()
    {
        Purchaser.instance.Buyproduct3();
       // show.text = "purchase3";
    }
}
