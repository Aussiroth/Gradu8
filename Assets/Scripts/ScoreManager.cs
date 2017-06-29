using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;// .UI for ui related

public class ScoreManager : MonoBehaviour {

    public Text scoreText;
    public Text hiScoreText;
    public Text jellyScoreText;

    public float scoreCount;
    public float hiScoreCount;
    public int jellyScoreCount;

    public float pointsPerSecond;
	public int powerupMultiplier;

    public bool scoreIncreasing;
	public bool scorePowerup;
   
    // Use this for initialization
	void Start () {
		if(PlayerPrefs.HasKey("HighScore"))
		{
			hiScoreCount = PlayerPrefs.GetFloat("HighScore");
		}
		//powerupMultiplier = 4;
	}
	
	// Update is called once per frame
	void Update () {

        if (scoreIncreasing)
        {
			if (scorePowerup)
				scoreCount += pointsPerSecond * Time.deltaTime * powerupMultiplier;
			else
				scoreCount += pointsPerSecond * Time.deltaTime;
        }

        if(scoreCount > hiScoreCount)
        {
            hiScoreCount = scoreCount;
            PlayerPrefs.SetFloat("HighScore", hiScoreCount);//saves hiScore into computer
        }

        scoreText.text = "score : " + Mathf.Round(scoreCount);
        hiScoreText.text = "High Score : " + Mathf.Round(hiScoreCount);
        jellyScoreText.text = jellyScoreCount.ToString();

    }

    public void AddScore(int pointsToAdd)
    {
		if(scorePowerup)
        {
			pointsToAdd = pointsToAdd * powerupMultiplier;
        }
        scoreCount += pointsToAdd;
    }

    public void JellyScore(int scoreAmount)
    {
        jellyScoreCount += scoreAmount;
        
    }

    public void BombDeduct(int bombAmount)
    {
        jellyScoreCount -= bombAmount;

    }
}
