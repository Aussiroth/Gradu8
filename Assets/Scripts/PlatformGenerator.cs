using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

	public GameObject thePlatform;
	public Transform generationPoint;
	public float distanceBetween;

	public GameObject[] thePlatforms;
	private float[] platformWidths;

	public float distanceBetweenMin;
	public float distanceBetweenMax;

	private int platformChosen;
	private float minHeight;
	private float maxHeight;
	public Transform maxHeightPoint;
	public float maxHeightChange;
	private float newHeight;

	// Use this for initialization
	void Start () {
		platformWidths = new float[thePlatforms.Length];
		for (int i = 0; i < thePlatforms.Length; i++) {
			platformWidths[i] = thePlatforms[i].GetComponent<BoxCollider2D> ().size.x;
		}
		minHeight = transform.position.y;
		maxHeight = maxHeightPoint.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < generationPoint.position.x) {
			//Decide which platform to make
			platformChosen = Random.Range(0, thePlatforms.Length);
			
			distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);

			//get new y coordinate of platform
			newHeight = transform.position.y + Random.Range (-maxHeightChange, maxHeightChange);
			if (newHeight > maxHeight)
				newHeight = maxHeight;
			if (newHeight < minHeight)
				newHeight = minHeight;

			transform.position = new Vector3 (transform.position.x + platformWidths[platformChosen]/2 + distanceBetween, newHeight, transform.position.z);

			Instantiate (thePlatforms[platformChosen], transform.position, transform.rotation);
			//Shift generation point to end of platform
			transform.position = new Vector3(transform.position.x + platformWidths[platformChosen]/2, transform.position.y, transform.position.z);
		}
		
	}
}
