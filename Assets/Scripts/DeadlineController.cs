using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadlineController : MonoBehaviour {

    public float moveSpeed;
    public float initialSpeed;

    private Rigidbody2D myRigidbody;

    void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();
    }
	
	void Update () {
        myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y);
    }

    public void AddSpeed(int speed)
    {
         moveSpeed = moveSpeed + speed;
    }

    public void ReduceSpeed(int speed)
    {
        moveSpeed = moveSpeed - speed;
    }

    public void ResetSpeed()
    {
        moveSpeed = initialSpeed;
    }

}
