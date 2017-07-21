using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour {

	public float platformLength;
	public float leftBorder;
	public float rightBorder;

	public float moveSpeed;
	private bool rightwards;

	// Use this for initialization
	void Awake () {
		platformLength = 0;
		rightwards = true;
	}
	
	// Update is called once per frame
	void Update () {
		//check for direction of travel, then check for boundary
		//reverse direction if we exceed boundary
		if (rightwards)
		{
			if (gameObject.transform.position.x < rightBorder)
			{
				gameObject.transform.position = new Vector3(gameObject.transform.position.x + moveSpeed*Time.deltaTime, 
											gameObject.transform.position.y, gameObject.transform.position.z);
			}
			else
			{
				rightwards = false;
			}
		}
		else
		{
			if (gameObject.transform.position.x > leftBorder)
			{
				gameObject.transform.position = new Vector3(gameObject.transform.position.x - moveSpeed*Time.deltaTime, 
					gameObject.transform.position.y, gameObject.transform.position.z);
			}
			else
			{
				rightwards = true;
			}
		}
	}

	public void setPlatformLength(float newLength)
	{
		platformLength = newLength;
		//shorten the borders a bit so spikes dont go too close to the edge
		leftBorder = gameObject.transform.position.x - platformLength/2 + 1.0f;
		rightBorder = gameObject.transform.position.x + platformLength/2 - 1.0f;
	}
}
