using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

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

        FindObjectOfType<BombManager>().isPaused = true;
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

        FindObjectOfType<BombManager>().isPaused = false;
    }

    public void RestartGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        FindObjectOfType<GameManager>().Reset();
    }

    public void QuitToMain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenuLevel);
        //Application.LoadLevel(mainMenuLevel);
    }
}
