using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerupManager : MonoBehaviour {

    private bool doublePoints;
    private bool safeMode;

    private bool powerupActive;

    private float powerupLengthCounter;

    private ScoreManager theScoreManager;
    private PlatformGenerator thePlatformGenerator;
    private GameManager theGameManager;

    private float normalPointsPerSecond;
    private float spikeRate;

    private PlatformDestroyer[] spikeList;

	private int[] storedPowerUps;
	public Text powerupText;

    // Use this for initialization
    void Start () {
        theScoreManager = FindObjectOfType<ScoreManager>();
        thePlatformGenerator = FindObjectOfType<PlatformGenerator>();
        theGameManager = FindObjectOfType<GameManager>();
		storedPowerUps = new int[2];
		for (int i = 0; i < storedPowerUps.Length; i++)
			storedPowerUps [i] = 0;
	}
	
	// Update is called once per frame
	void Update () {

        if (powerupActive)
        {
            powerupLengthCounter -= Time.deltaTime;

            if(theGameManager.powerupReset)
            {
                powerupLengthCounter = 0;
                theGameManager.powerupReset = false; 
            }

            if(doublePoints)
            {
                theScoreManager.pointsPerSecond = normalPointsPerSecond * 2.75f;
                theScoreManager.shouldDouble = true;
            }

            if(safeMode)
            {
                thePlatformGenerator.randomSpikeThreshold = 0f;
            }

            //resets to normal state once powerup is finished
            if (powerupLengthCounter <= 0)
            {
                theScoreManager.pointsPerSecond = normalPointsPerSecond;
                theScoreManager.shouldDouble = false;

                thePlatformGenerator.randomSpikeThreshold = spikeRate;

                powerupActive = false;
            }

        }

		//Update the shown number of powerups.
		string powerupOutput = "";
		for (int i = 0; i < storedPowerUps.Length; i++) 
		{
			powerupOutput += storedPowerUps [i] + "\n";
		}
		powerupText.text = powerupOutput;
	}

	//Precond: powerupSelector needs to be within 1 to max number of powerups
	//Postcond: number of powerups of the type stored by the player is increased by 1.
	public void IncreasePowerup(int powerupSelector)
	{
		storedPowerUps [powerupSelector]++;
	}

    public void ActivatePowerup(bool points, bool safe, float time)
    {
        doublePoints = points;
        safeMode = safe;
        powerupLengthCounter = time;

        normalPointsPerSecond = theScoreManager.pointsPerSecond;
        spikeRate = thePlatformGenerator.randomSpikeThreshold;

        if (safeMode)
        {
            spikeList = FindObjectsOfType<PlatformDestroyer>();
            for (int i = 0; i < spikeList.Length; i++)
            {
                if (spikeList[i].gameObject.name.Contains("Spikes"))
                {
                    spikeList[i].gameObject.SetActive(false);
                }
            }
        }
        powerupActive = true;
    }
}
