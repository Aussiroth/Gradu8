using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	public float jumpForce;
	public float jumpTime;

	private float jumpTimeCounter;
	private Rigidbody2D myRigidBody;
	//private Collider2D myCollider;

	public bool grounded;
	public LayerMask isGround;
	public Transform groundCheck;
	public float groundCheckRadius;

	// Use this for initialization
	void Start () {
		jumpTimeCounter = jumpTime;
		myRigidBody = GetComponent<Rigidbody2D> ();
		//myCollider = GetComponent<Collider2D> ();
	}
	
	// Update is called once per frame
	void Update () {

		//grounded = Physics2D.IsTouchingLayers (myCollider, isGround);
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, isGround);
		if (grounded) {
			jumpTimeCounter = jumpTime;
		} 
		else {
			//If player is in the air, and he is not holding down the jump button, set timer below 0
			//So if player runs off platform without jumping or releases jump halfway, he can't start jumping again
			if (!(Input.GetKey (KeyCode.Space) || Input.GetMouseButton (0))) {
				jumpTimeCounter = -1;
			}
		}

		myRigidBody.velocity = new Vector2 (moveSpeed, myRigidBody.velocity.y);

		if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown (0)) && grounded) {
			setVelocity (myRigidBody.velocity.x, jumpForce);
		}

		//Check for jump press is held down
		if ((Input.GetKey (KeyCode.Space) || Input.GetMouseButton (0)) && jumpTimeCounter > 0) {
			setVelocity (myRigidBody.velocity.x, jumpForce);
			jumpTimeCounter -= Time.deltaTime;
		}

	}

	//Precond: 2 floats representing x and y speed of the character (x, y)
	//Postcond: speed of the character set to new x and y values
	void setVelocity(float xspeed, float yspeed){
		myRigidBody.velocity = new Vector2 (xspeed, yspeed);
	}
}
