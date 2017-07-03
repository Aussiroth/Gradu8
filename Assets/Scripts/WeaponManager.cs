using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour {

	public ObjectPooler weaponPool;
	private PlayerController thePlayer;

	// Use this for initialization
	void Start () {
		thePlayer = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//Postcond: weapon created, set to player position and activated
	public void fireWeapon()
	{
		//Move the weapon to the position of the player and make it active when 'fired'
		GameObject newWeapon = weaponPool.GetPooledObject();
		newWeapon.transform.position = thePlayer.transform.position;
		newWeapon.SetActive(true);
	}
}
