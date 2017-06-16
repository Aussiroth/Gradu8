﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Transform platformGenerator;
    private Vector3 platformStartPoint;

    public PlayerController thePlayer;
    private Vector3 playerStartPoint;

    private PlatformDestroyer[] platformList;

    private ScoreManager theScoreManager;

    public DeathMenu theDeathScreen;

    public bool powerupReset;

	// Use this for initialization
	void Start () {
        platformStartPoint = platformGenerator.position;
        playerStartPoint = thePlayer.transform.position;

        theScoreManager = FindObjectOfType<ScoreManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RestartGame()
    {
        theScoreManager.scoreIncreasing = false;
        thePlayer.gameObject.SetActive(false);

        theDeathScreen.gameObject.SetActive(true);
        
        //StartCoroutine("RestartGameCo");//calls the RestartGameCo() method
    }

    public void Reset()
    {
        theDeathScreen.gameObject.SetActive(false);
        platformList = FindObjectsOfType<PlatformDestroyer>();
        for (int i = 0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }

        thePlayer.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        thePlayer.gameObject.SetActive(true);

        theScoreManager.scoreCount = 0;
        theScoreManager.scoreIncreasing = true;

        powerupReset = true;
    }

    /* //Method to restart game
     public IEnumerator RestartGameCo()
     {
         theScoreManager.scoreIncreasing = false;
         thePlayer.gameObject.SetActive(false);//To make player invisible when it touches Catcher
         yield return new WaitForSeconds(0.5f);//sets a 0.5s delay before exe next line

         platformList = FindObjectsOfType<PlatformDestroyer>();
         for(int i = 0; i < platformList.Length; i++)
         {
             platformList[i].gameObject.SetActive(false);
         }

         thePlayer.transform.position = playerStartPoint;
         platformGenerator.position = platformStartPoint;
         thePlayer.gameObject.SetActive(true);

         theScoreManager.scoreCount = 0;
         theScoreManager.scoreIncreasing = true;
     } */
}