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
    public static bool coilyDied = false;
    public static bool enemiesFrozen = false;

    public static bool doesCoilyExist = false;
    public static int score = 0;
    public Text UIScore;

    public Transform redBall;
    public Transform greenBall;
    public Transform coilyBall;
    public GameObject life1;
    public GameObject life2;

    public AudioSource Sounder;
    public AudioClip winner;

    public Animator m_animator;


    LeaderboardBehaviour ldrBoard;

    void Start()
    {
        ldrBoard = FindObjectOfType<LeaderboardBehaviour>();
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
            StartCoroutine(newLevel());
            
            //check for all tiles changed - reset the level
        }

        if (qbertLives < 1)
        {
            SceneManager.LoadScene("Game Over");
            ldrBoard.currentScore = score;
        }
        
        if (qbertLives == 2)
        {
            life1.GetComponent<Image>().enabled = false;
        }

        if (qbertLives == 1)
        {
            life2.GetComponent<Image>().enabled = false;
        }

        if (enemiesFrozen == true) StartCoroutine(freezeEnemies()) ;

        UIScore.text = score.ToString();
        //updates score

        
    }

    void restartPlay()
    {
        TilesToChange = 2;
        qbertLives = 3;
        death = false;
        doesCoilyExist = false;
        CoilyBallBehaviour.isTracking = false;
        life2.GetComponent<Image>().enabled = true;
        life1.GetComponent<Image>().enabled = true;
        score = 0;
    }

    IEnumerator newLevel() 
    {
        score += 1000;
        if (LeftElevatorBehaviour.leftAvailable == true) score += 100;
        if (RightElevatorBehaviour.rightAvailable == true) score += 100;
        ldrBoard.currentScore = score;
        TilesToChange = 2;
        Sounder.clip = winner;
        Sounder.Play();
        //add points and reset tilesToChange
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(3);
        Time.timeScale = 1f;

        if (ldrBoard.isHighScore()) SceneManager.LoadScene("Game Over");

        else SceneManager.LoadScene("MainMenu");

    }


    IEnumerator createRedBall()
    {
        yield return new WaitForSeconds(8); // how often to spawn
        if (enemiesFrozen == true)
        {
            yield return new WaitForSeconds(5);
            Instantiate(redBall, new Vector3(0, 3, 0), redBall.rotation); //Ball will spawn above top tile

            StartCoroutine(createRedBall()); //Recursive
        }
        else
        {
            Instantiate(redBall, new Vector3(0, 3, 0), redBall.rotation); //Ball will spawn above top tile

            StartCoroutine(createRedBall()); //Recursive
        }
    }

    IEnumerator createGreenBall()
    {
        yield return new WaitForSeconds(14);
        if (enemiesFrozen == true)
        {
            yield return new WaitForSeconds(5);
            Instantiate(greenBall, new Vector3(0, 3, 0), greenBall.rotation);
            StartCoroutine(createGreenBall());
        }
        else
        {
            Instantiate(greenBall, new Vector3(0, 3, 0), greenBall.rotation);

            StartCoroutine(createGreenBall()); //Recursive
        }
    }

    IEnumerator createCoilyBall()
    {
       
            
            yield return new WaitForSeconds(5);
            
            if (Random.Range(0, 2) == 0)
            {
                Instantiate(coilyBall, new Vector3(0, 2, -1), coilyBall.rotation); //Spawn at T2
            }
            else                                                                                         //OR
            {
                Instantiate(coilyBall, new Vector3(1, 2, 0), coilyBall.rotation); //Spawn at T3
            }
        coilyDied = false;
    }

    IEnumerator freezeEnemies()
    {

        yield return new WaitForSeconds(5);
        enemiesFrozen = false;
    }

}