using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour 
{
	private bool wPressed, aPressed, sPressed, dPressed, spacePressed;
	private int maxJumps = 1;
	private Rigidbody myRigidbody;
	private int jumpCount;
	public float moveSpeed = 0.0f;
	public float jumpHeight = 0.0f;
	// Use this for initialization
	void Start () 
	{
		myRigidbody = GetComponent <Rigidbody> ();
		jumpCount = maxJumps;
	}
	
	// Update is called once per frame
	void Update () 
	{
		wPressed = Input.GetKey (KeyCode.W);
		sPressed = Input.GetKey (KeyCode.S);
		aPressed = Input.GetKey (KeyCode.A);
		dPressed = Input.GetKey (KeyCode.D);
		spacePressed = Input.GetKey (KeyCode.Space);
	}
	void FixedUpdate ()
	{
		if (wPressed == true) {
			transform.position += transform.forward * moveSpeed;
		}
		if (sPressed == true) {
			transform.position -= transform.forward * moveSpeed;
		}
		if (aPressed == true) {
			transform.position -= transform.right * moveSpeed;
		}
		if (dPressed == true) {
			transform.position += transform.right * moveSpeed;
		}
		if (spacePressed == true) 
		{
			if (jumpCount > 0)
			{
				Jump ();
			}
		}
	}
	public void Jump ()
	{
		myRigidbody.velocity = transform.up * jumpHeight;
		jumpCount -= 1;
	}
	void OnCollisionEnter (Collision collidedObject)
	{
		if (collidedObject.gameObject.tag == "Ground")
		{
			jumpCount = maxJumps;
		}
	}
}

//Improvement: While the Movement Script allows the player to move, the moveSpeed variable changes in speed too when changed. 
//			   The Improvement can be a refined moveSpeed variable which allows the player to change the speed in small amounts rather than 
//				an excessively large speed difference.
