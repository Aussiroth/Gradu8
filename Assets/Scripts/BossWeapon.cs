using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeapon : MonoBehaviour {

	public float baseMoveSpeed;
	public float currMoveSpeed;
	public Rigidbody2D myRigidBody;

	public PlayerController thePlayer;

	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent<Rigidbody2D>();
		thePlayer = FindObjectOfType<PlayerController>();
	}

	// Update is called once per frame
	void Update () {
		//Basically the projectile moves at a constant speed towards the player, equal to baseMoveSpeed
		currMoveSpeed = thePlayer.moveSpeed - baseMoveSpeed;
		myRigidBody.velocity = new Vector2(currMoveSpeed, myRigidBody.velocity.y);
		//boss weapons go left, so use the usual destruction script
	}

}
