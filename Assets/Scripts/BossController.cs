﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {

	public float health;
	public float verticalSpeed;

	public PlayerController thePlayer;
	private float horizontalDisplacement;

	public Transform maxHeightPoint;
	public Transform minHeightPoint;

	public float stopTime;
	public float attackTime;
	public float attackThreshold;

	public ObjectPooler weaponPooler;

	private bool higher;
	private bool atPosition;
	private float newHeight;
	private float timeLeft;
	private float timeToAttack;

	// Use this for initialization
	void Start () {
		thePlayer = FindObjectOfType<PlayerController>();
		horizontalDisplacement = transform.position.x - thePlayer.transform.position.x;
		timeLeft = 0;
		atPosition = false;
		higher = false;
		timeToAttack = attackTime;
	}
	
	// Update is called once per frame
	void Update () {
		//if timer is out, then get dragon to go to new position
		if (timeLeft <= 0)
		{
			atPosition = false;
			newHeight = Random.Range(minHeightPoint.position.y, maxHeightPoint.position.y);
			if (newHeight > transform.position.y)
				higher = true;
			else
				higher = false;
			timeLeft = stopTime;
		}
		//check if dragon is at its point, if so then just deduct time
		if (atPosition)
		{
			timeLeft -= Time.deltaTime;
			transform.position = new Vector3(thePlayer.transform.position.x + horizontalDisplacement, transform.position.y, transform.position.z);
		}
		//else move dragon, then check if it reached its new point
		else
		{
			if (higher)
			{
				transform.position = new Vector3(thePlayer.transform.position.x + horizontalDisplacement, 
					transform.position.y + Time.deltaTime * verticalSpeed, transform.position.z);
				if (transform.position.y > newHeight)
				{
					atPosition = true;
				}
			}
			else
			{
				transform.position = new Vector3(thePlayer.transform.position.x + horizontalDisplacement, 
					transform.position.y - Time.deltaTime * verticalSpeed, transform.position.z);
				if (transform.position.y < newHeight)
				{
					atPosition = true;
				}
			}
		}
		//perform boss attack check here
		timeToAttack -= Time.deltaTime;
		if (timeToAttack <= 0)
		{
			timeToAttack = attackTime;
			if (Random.Range(0, 100) < attackThreshold)
			{
				GameObject bossWeapon = weaponPooler.GetPooledObject();
				bossWeapon.transform.position = transform.position;
				bossWeapon.SetActive(true);
			}
		}
	}


	public void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "weapon")
		{
			health -= 1;
			other.gameObject.SetActive(false);
		}
	}
}