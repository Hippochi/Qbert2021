using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayState : MonoBehaviour
{
    public static int TilesToChange = 2;
    public static int qbertLives = 3;
    public static bool death = false; //lost a life

    public static bool doesCoilyExist = false;
    public static int score = 0;
    public Text UIScore;

    public Transform redBall;
    public Transform greenBall;
    public Transform coilyBall;

    void Start()
    {
        StartCoroutine(createRedBall());
        StartCoroutine(createGreenBall());
        restartPlay();
    }

    void Update()
    {
        if (doesCoilyExist == false)
        {
            doesCoilyExist = true;
            StartCoroutine(createCoilyBall());
        }

        if (TilesToChange == 0)
        {
            Debug.Log("Win");
            doesCoilyExist = false;
            StartCoroutine(newLevel());
            
            //check for all tiles changed - reset the level
        }

        if (qbertLives < 1)
        {
            SceneManager.LoadScene("Game Over");
        }

        UIScore.text = score.ToString(); 
        //updates score
      
    }

    void restartPlay()
    {
        TilesToChange = 28;
        qbertLives = 3;
        death = false;
        doesCoilyExist = false;
        CoilyBallBehaviour.isTracking = false;
        score = 0;
    }

    IEnumerator newLevel() 
    {
        score += 1000;
        TilesToChange = 28;
        //add points and reset tilesToChange
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(3);
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }


    IEnumerator createRedBall()
    {
        yield return new WaitForSeconds(6.33f); // how often to spawn
        Instantiate(redBall, new Vector3(0, 3, 0), redBall.rotation); //Ball will spawn above top tile

        StartCoroutine(createRedBall()); //Recursive
    }

    IEnumerator createGreenBall()
    {
        yield return new WaitForSeconds(18);
        Instantiate(greenBall, new Vector3(0, 2, 0), greenBall.rotation);

        StartCoroutine(createGreenBall()); //Recursive
    }

    IEnumerator createCoilyBall()
    {
       
            
            yield return new WaitForSeconds(3);

            if (Random.Range(0, 2) == 0)
            {
                Instantiate(coilyBall, new Vector3(0, 2, -1), coilyBall.rotation); //Spawn at T2
            }
            else                                                                                         //OR
            {
                Instantiate(coilyBall, new Vector3(1, 2, 0), coilyBall.rotation); //Spawn at T3
            }

    }

}