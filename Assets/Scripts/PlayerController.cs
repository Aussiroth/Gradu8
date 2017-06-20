using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerController : MonoBehaviour {
    public float moveSpeed;
    public float jumpForce;

	//for the 3 different speeds
	public float slowMoveSpeed;
	public float medMoveSpeed;
	public float fastMoveSpeed;

    public float jumpTime;
    private float jumpTimeCounter;

    private bool canDoubleJump;

    private Rigidbody2D myRigidbody;

    public bool groundedCheck1;
	public bool groundedCheck2;
    public LayerMask whatIsGround;
    public Transform groundCheck;
	public Transform groundCheck2;
    public float groundCheckRadius;

	//health system stuff
	public int maxLives;
	private int currLives;
	public Text healthText;

    
    //private Collider2D myCollider;
    private Animator myAnimator;

    public GameManager theGameManager;

    public AudioSource jumpSound;
    public AudioSource deathSound;

	// Use this for initialization
	void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();

        //myCollider = GetComponent<Collider2D>();

        myAnimator = GetComponent<Animator>();
        jumpTimeCounter = jumpTime;
        //stoppedJumping = true;
		currLives = maxLives;
		moveSpeed = medMoveSpeed;
    }
	
	// Update is called once per frame
	void Update () {
        //grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);

        groundedCheck1 = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
		groundedCheck2 = Physics2D.OverlapCircle(groundCheck2.position, groundCheckRadius, whatIsGround);
		//do variable updates if char is on the ground
		if (groundedCheck1 || groundedCheck2)
		{
			jumpTimeCounter = -1;
			canDoubleJump = false;
		}

        //X-axis movement
        myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y);

        //Enabling jumping
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            //Enable jump only when touching the platform
			if (groundedCheck1 || groundedCheck2)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
				canDoubleJump = true;
				jumpTimeCounter = jumpTime;
                jumpSound.Play();
            }
            //Enable double jump
            else if (canDoubleJump)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
                jumpTimeCounter = jumpTime;
                canDoubleJump = false;
                jumpSound.Play();
            }
        }

        if((Input.GetKey (KeyCode.Space) || Input.GetMouseButton(0)))
        {
            if (jumpTimeCounter > 0)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
        }
		//Prevents multiple jumps in the air
		if(Input.GetKeyUp (KeyCode.Space) || Input.GetMouseButtonUp(0))
		{
			jumpTimeCounter = -1;
		}

        //reset jumpTimeCounter once player hits the ground

        myAnimator.SetFloat("Speed", myRigidbody.velocity.x);
		myAnimator.SetBool("Grounded", groundedCheck1 || groundedCheck2);

		//finally, update the number of lives
		//healthText.text = "Lives left: " + currLives;
		healthText.text = Convert.ToString(Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
		if (other.gameObject.tag == "killbox") 
		{
			theGameManager.RestartGame ();
			deathSound.Play ();
		} 
		else if (other.gameObject.tag == "obstacle") 
		{
			//if we run into an obstacle, remove 1 life.
			//also deactivate the obstacle to prevent multiple life loss
			currLives-=1;
			other.gameObject.SetActive (false);
			//if we run out of lives, kill the character similarly to killbox
			{
				theGameManager.RestartGame ();
				deathSound.Play ();
			}
		}
    }

	//Precond: integer is 1, 2 or 3
	//Postcond: player speed is set to slow for 1, normal for 2, fast for 3
	public void setPlayerSpeed(int newSpeed)
	{
		switch(newSpeed)
		{
		case 1:
			moveSpeed = slowMoveSpeed;
			break;
		case 2:
			moveSpeed = medMoveSpeed;
			break;
		case 3:
			moveSpeed = fastMoveSpeed;
			break;
		}
	}
}
