using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    

    public void StartGame()
    {
        SceneManager.LoadScene("PlayScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void goToBoard()
    {
        SceneManager.LoadScene("LeaderBoard");
    }

    public void goToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }


}