using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	public float jumpForce;
	private Rigidbody2D myRigidBody;

	public bool grounded;
	public LayerMask isGround;

	private Collider2D myCollider;

	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent<Rigidbody2D> ();
		myCollider = GetComponent<Collider2D> ();
	}
	
	// Update is called once per frame
	void Update () {

		grounded = Physics2D.IsTouchingLayers (myCollider, isGround);

		myRigidBody.velocity = new Vector2 (moveSpeed, myRigidBody.velocity.y);

		if (Input.GetMouseButtonDown (0) && grounded) {
			myRigidBody.velocity = new Vector2 (myRigidBody.velocity.x, jumpForce);
		}
	}
}
