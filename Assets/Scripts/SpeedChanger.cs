using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedChanger : MonoBehaviour {

	public PlayerController thePlayer;
	// Use this for initialization
	void Start () {
		thePlayer = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetSpeedSlow()
	{
		thePlayer.setPlayerSpeed (1);
	}

	public void setSpeedMed()
	{
		thePlayer.setPlayerSpeed (2);
	}

	public void setSpeedFast()
	{
		thePlayer.setPlayerSpeed (3);
	}
}
