﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossPauseMenu : MonoBehaviour {

	public string mainMenuLevel;

	public GameObject pauseMenu;

	public void PauseGame()
	{
		//stop the scoring system when paused
		Time.timeScale = 0f;

		pauseMenu.SetActive(true);

		//Need to pause every JellyManager scripts since there are more than 1 JellyManager present
		JellyManager[] j = FindObjectsOfType(typeof(JellyManager)) as JellyManager[];
		foreach (JellyManager jelly in j)
		{
			jelly.isPaused = true;
		}

		BlacklyManager[] bk = FindObjectsOfType(typeof(BlacklyManager)) as BlacklyManager[];
		foreach (BlacklyManager jelly in bk)
		{
			jelly.isPaused = true;
		}

		BellyManager[] bu = FindObjectsOfType(typeof(BellyManager)) as BellyManager[];
		foreach (BellyManager jelly in bu)
		{
			jelly.isPaused = true;
		}

		GellyManager[] g = FindObjectsOfType(typeof(GellyManager)) as GellyManager[];
		foreach (GellyManager jelly in g)
		{
			jelly.isPaused = true;
		}

		RellyManager[] r = FindObjectsOfType(typeof(RellyManager)) as RellyManager[];
		foreach (RellyManager jelly in r)
		{
			jelly.isPaused = true;
		}

		BombManager[] b = FindObjectsOfType(typeof(BombManager)) as BombManager[];
		foreach (BombManager bomb in b)
		{
			bomb.isPaused = true;
		}
	}

	public void ResumeGame()
	{
		//resume scoring system
		Time.timeScale = 1f;

		pauseMenu.SetActive(false);

		JellyManager[] j = FindObjectsOfType(typeof(JellyManager)) as JellyManager[];
		foreach (JellyManager jelly in j)
		{
			jelly.isPaused = false;
		}

		BlacklyManager[] bk = FindObjectsOfType(typeof(BlacklyManager)) as BlacklyManager[];
		foreach (BlacklyManager jelly in bk)
		{
			jelly.isPaused = false;
		}

		BellyManager[] bu = FindObjectsOfType(typeof(BellyManager)) as BellyManager[];
		foreach (BellyManager jelly in bu)
		{
			jelly.isPaused = false;
		}

		GellyManager[] g = FindObjectsOfType(typeof(GellyManager)) as GellyManager[];
		foreach (GellyManager jelly in g)
		{
			jelly.isPaused = false;
		}

		RellyManager[] r = FindObjectsOfType(typeof(RellyManager)) as RellyManager[];
		foreach (RellyManager jelly in r)
		{
			jelly.isPaused = false;
		}

		BombManager[] b = FindObjectsOfType(typeof(BombManager)) as BombManager[];
		foreach (BombManager bomb in b)
		{
			bomb.isPaused = false;
		}
	}

	public void RestartGame()
	{
		pauseMenu.SetActive(false);
		Time.timeScale = 1f;
		FindObjectOfType<BossGameManager>().Reset();
	}

	public void QuitToMain()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene(mainMenuLevel);
		//Application.LoadLevel(mainMenuLevel);
	}
}
