using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

	public GameObject thePlatform;
	public Transform generationPoint;
	public float distanceBetween;
	private float platformWidth;

	public GameObject[] thePlatforms;
	public int[] platformWidths;

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
		platformWidth = thePlatform.GetComponent<BoxCollider2D> ().size.x;

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

			transform.position = new Vector3 (transform.position.x + platformWidth + distanceBetween, newHeight, transform.position.z);

			Instantiate (thePlatforms[platformChosen], transform.position, transform.rotation);
		}
		
	}
}
