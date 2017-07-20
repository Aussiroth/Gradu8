using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour {

	public ObjectPooler weaponPool;
	private PlayerController thePlayer;

    public GameObject fullScreen;
    public GameObject timeHack;

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
		//shift weapon roughly to center of player
		newWeapon.transform.position = new Vector3(thePlayer.transform.position.x, thePlayer.transform.position.y + 1.0f, thePlayer.transform.position.z);
		newWeapon.SetActive(true);
	}

    public void FullAttack()
    {
        fullScreen.SetActive(true);
        StartCoroutine("Delay");

    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1.0f);
        fullScreen.SetActive(false);
    }

    public void TimeHack()
    {
        timeHack.SetActive(true);
        Time.timeScale = 0f;

        StartCoroutine("TimeStop");
    }

    IEnumerator TimeStop()
    {
        yield return new WaitForSecondsRealtime(2.5f);

        Time.timeScale = 1f;
        timeHack.SetActive(false);
    }
}
