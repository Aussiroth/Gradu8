﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerupManager : MonoBehaviour {

    private bool doublePoints;
    private bool safeMode;

    private bool powerupActive;
	private int activePowerupNum;

    private float powerupLengthCounter;
	public float powerupTime;

    private ScoreManager theScoreManager;
    private PlatformGenerator thePlatformGenerator;
    private GameManager theGameManager;

    private float normalPointsPerSecond;
    private float spikeRate;

    private PlatformDestroyer[] spikeList;

	private int[] storedPowerUps;
	public Text safemodeText;
	public Text doublePointText;

    // Use this for initialization
    void Start () {
        theScoreManager = FindObjectOfType<ScoreManager>();
        thePlatformGenerator = FindObjectOfType<PlatformGenerator>();
        theGameManager = FindObjectOfType<GameManager>();
		storedPowerUps = new int[2];
		//0 is double points, 1 is safemode
		for (int i = 0; i < storedPowerUps.Length; i++)
			storedPowerUps [i] = 0;
	}
	
	// Update is called once per frame
	void Update () {

        if (powerupActive)
        {
            powerupLengthCounter -= Time.deltaTime;

			//check to turn off powerup if player dies
            if(theGameManager.powerupReset)
            {
                powerupLengthCounter = 0;
                theGameManager.powerupReset = false; 
            }

            /*if(doublePoints)
            {
                theScoreManager.pointsPerSecond = normalPointsPerSecond * 2.75f;
                theScoreManager.shouldDouble = true;
            }*/

            //resets to normal state once powerup is finished
            if (powerupLengthCounter <= 0)
            {
                theScoreManager.shouldDouble = false;
                thePlatformGenerator.randomSpikeThreshold = spikeRate;
                powerupActive = false;
            }

        }

		//Update the shown number of powerups.
		safemodeText.text = storedPowerUps [1].ToString();
		doublePointText.text = storedPowerUps [0].ToString();
	}

	//Precond: powerupSelector needs to be within 1 to max number of powerups
	//Postcond: number of powerups of the type stored by the player is increased by 1.
	public void IncreasePowerup(int powerupSelector)
	{
		storedPowerUps [powerupSelector]++;
	}

	public void ActivatePowerup(int powerupNum)
	{
		//Check for powerup
		if (storedPowerUps [powerupNum] > 0) 
		{
			//remove a powerup
			storedPowerUps[powerupNum]--;
			//initialise timer on powerup
			powerupLengthCounter = powerupTime;
			activePowerupNum = powerupNum;
			powerupActive = true;
			//activate relevant powerup
			switch (powerupNum) {
			case(0):
				DoDoublePoints ();
				break;
			case(1):
				DoSafeMode ();
				break;
			}
		}
	}

	//call when double points powerup activated
	void DoDoublePoints()
	{
		theScoreManager.shouldDouble = true;
	}

	//call when safe mode powerup activated
	void DoSafeMode()
	{
		//clear current spikes
		spikeList = FindObjectsOfType<PlatformDestroyer>();
		for (int i = 0; i < spikeList.Length; i++)
		{
			if (spikeList[i].gameObject.name.Contains("Spikes"))
			{
				spikeList[i].gameObject.SetActive(false);
			}
		}
		spikeRate = thePlatformGenerator.randomSpikeThreshold;
		thePlatformGenerator.randomSpikeThreshold = 0f;
	}
}
