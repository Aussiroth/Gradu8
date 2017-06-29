using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public string mainMenuLevel;

    public GameObject pauseMenu;

    public void PauseGame()
    {
        Time.timeScale = 0f;//stop the scoring system when paused
        pauseMenu.SetActive(true);
        FindObjectOfType<JellyManager>().isPaused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;//resume scoring system
        pauseMenu.SetActive(false);
        FindObjectOfType<JellyManager>().isPaused = false;
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
