using UnityEngine;
using System.Collections;

public class DynamicScroller : MonoBehaviour {


    public float backgroundsize;
    public float lastCameraX;
    public float parallexSpeed;
    Transform cameratransform;
    Transform[] layers;

    float viewzone=20;
    int leftindex;
    int rightindex;


	// Use this for initialization
	void Start () {
        cameratransform = Camera.main.transform;
        lastCameraX = cameratransform.position.x;

        layers = new Transform[transform.childCount];

        for(int i =0; i<transform.childCount;i++)
        {
            layers[i] = transform.GetChild(i);
        }


        leftindex = 0;
        rightindex = layers.Length - 1;


    }



    public void ScrollLeft()
    {
        int lastright = rightindex;

        layers[rightindex].position = Vector3.right * (layers[leftindex].position.x - backgroundsize);

        leftindex = rightindex;

        rightindex--;

        if (rightindex < 0)
        {
            rightindex = layers.Length-1;
        }
    }




    public void ScrollRight()
    {
        int lastleft = leftindex;

        layers[leftindex].position = Vector3.right * (layers[rightindex].position.x + backgroundsize);
        //Debug.Log("value: " + Vector3.right * (layers[rightindex].position.x + backgroundsize));


        rightindex = leftindex;

        leftindex++;

        if (leftindex == layers.Length)
        {
            leftindex = 0;
        }
    }


    void Update()
    {

        float deltaX = cameratransform.position.x - lastCameraX;
        transform.position += Vector3.right*(deltaX*parallexSpeed);
        lastCameraX = cameratransform.position.x;


        if (cameratransform.position.x < layers[leftindex].transform.position.x+ viewzone)
        {
            //not
           ScrollLeft();
        }

        if (cameratransform.position.x > layers[rightindex].transform.position.x - viewzone)
        {
            ScrollRight();

        }
    }

}
