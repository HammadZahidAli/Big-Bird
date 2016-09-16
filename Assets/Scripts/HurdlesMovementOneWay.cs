using UnityEngine;
using System.Collections;

public class HurdlesMovementOneWay : MonoBehaviour {
    //X positions for To and Fro

    public float diff = 0.5f;
    float x1, x2;

    // Speed 
    public float speed = 2f;
    public bool updown;
    public bool bouncePlank;

    // Use this for initialization
    void Start()
    {
        //speed = Random.Range (0.5f,2f);
        //if(!CentralVariables.GamePauseBool && !CentralVariables.ReviveGameBool)
        {
            //		if (!updown)
            x1 = gameObject.transform.localPosition.y;
            x2 = gameObject.transform.localPosition.y - diff;
            StartUpDown();
        }
        //		else
        //			StartUpDown ();

        //		if (bouncePlank)
        //			StartMovingBouncyPlanks ();

    }



    void StartUpDown()
    {


        LeanTween.moveLocalY(gameObject, x2, speed);
 
    }

    
}

