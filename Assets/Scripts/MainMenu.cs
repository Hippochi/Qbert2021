using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Update()
    {
        Start();
        QuitGame();
    }

    public void Start()
    {
       SceneManager.LoadScene("PlayScene");
    }

    public void Leaderboard()
    {
        SceneManager.LoadScene("LeaderBoard");
    }

    public void QuitGame()
    {
        Application.Quit();

    }

}
