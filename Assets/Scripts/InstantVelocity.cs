using UnityEngine;
using System.Collections;

public class InstantVelocity : MonoBehaviour {


	public Vector2 velocity = Vector2.zero;
	Rigidbody2D body2D;
    public float vel = 0.01f;

	void Awake()
	{
		body2D = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate()
	{
        //body2D.velocity = velocity;
       // transform.position = new Vector3(transform.position.x+ vel, transform.position.y,transform.position.z);
	}

}
