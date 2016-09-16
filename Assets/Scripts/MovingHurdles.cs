using UnityEngine;
using System.Collections;

public class MovingHurdles : MonoBehaviour {

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


        LeanTween.moveLocalY(gameObject, x1, speed).onComplete = delegate {
            LeanTween.moveLocalY(gameObject, x2, speed).onComplete = delegate {

                StartUpDown();
            };
        };
    }
    void StartMoving()
    {
        //if(!CentralVariables.GamePauseBool && !CentralVariables.ReviveGameBool) 
        {
            LeanTween.moveLocalX(gameObject, x1, speed).onComplete = delegate {
                LeanTween.moveLocalX(gameObject, x2, speed).onComplete = delegate {

                    StartMoving();
                };
            };
        }

    }

    void StartMovingBouncyPlanks()
    {

        LeanTween.moveLocalX(gameObject, x1, 5f).onComplete = delegate {
            LeanTween.moveLocalX(gameObject, 5f, speed).onComplete = delegate {

                StartMovingBouncyPlanks();
            };
        };
        //		LeanTween.move(gameObject,position1,0.5f).onComplete = delegate {
        //			LeanTween.move(gameObject,position2,0.5f).onComplete = delegate {
        //				StartMoving();
        //			};
        //		};
    }
}

