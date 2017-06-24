using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupActivator : MonoBehaviour {

	public PowerupManager thePowerupManager;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void activateDoublePoints()
	{
		thePowerupManager.ActivatePowerup (0);
	}

	public void activateSafeMode()
	{
		thePowerupManager.ActivatePowerup (1);
	}
}
