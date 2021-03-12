using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool isPaused = false;

    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        //set play state
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Pause()
    {
        //set pause state
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; 
        isPaused = true;
    }

    public void LoadMenu()
    {
        //returns to mainmenu
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        PlayState.score = 0;
        PlayState.qbertLives = 3;
        PlayState.coilyLives = 3;
        PlayState.TilesToChange = 28;
    }

}
