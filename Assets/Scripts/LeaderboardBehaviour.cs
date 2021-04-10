using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardBehaviour : MonoBehaviour
{
    public int currentScore;

    private void Awake()
    {
        int sessionCount = FindObjectsOfType<LeaderboardBehaviour>().Length;
        if (sessionCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public string getScore(int rank)
    {
        int rankScore;
        rankScore = PlayerPrefs.GetInt(rank + "HScore");
        return rankScore.ToString();
    }

    public string getName(int rank)
    {
        string rankName;
        rankName = PlayerPrefs.GetString(rank + "HScoreName");
        return rankName;
    }

    public void AddScore(string name)
    {
        int newScore;
        string newName;
        int oldScore;
        string oldName;
        newScore = currentScore;
        newName = name;
        for (int i = 0; i < 10; i++)
        {
            if (PlayerPrefs.HasKey(i + "HScore"))
            {
                if (PlayerPrefs.GetInt(i + "HScore") < newScore)
                {
                    // new score is higher than the stored score
                    oldScore = PlayerPrefs.GetInt(i + "HScore");
                    oldName = PlayerPrefs.GetString(i + "HScoreName");
                    PlayerPrefs.SetInt(i + "HScore", newScore);
                    PlayerPrefs.SetString(i + "HScoreName", newName);
                    newScore = oldScore;
                    newName = oldName;
                }
            }
            else
            {
                PlayerPrefs.SetInt(i + "HScore", newScore);
                PlayerPrefs.SetString(i + "HScoreName", newName);
                newScore = 0;
                newName = "";
            }
        }
    }

    public bool isHighScore()
    {
        return PlayerPrefs.GetInt("9HScore") < currentScore;
    }


    private void clearBoard()
    {
        for (int i = 0; i < 10; i++)
        {
            PlayerPrefs.SetInt(i + "HScore", 0);
            PlayerPrefs.SetString(i + "HScoreName", "");
        }
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.Save();
    }

}