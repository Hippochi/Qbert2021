using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NameInput : MonoBehaviour
{
    string playerName;
    int ind;
    bool isNameSet;
    LeaderboardBehaviour ldrBoard;

    Text txt;

    [SerializeField] Text scoretxt;

    [SerializeField] GameObject highlightOne;
    [SerializeField] GameObject highlightTwo;
    [SerializeField] GameObject highlightThree;
    [SerializeField] GameObject typeYourName;

    // Start is called before the first frame update
    void Start()
    {
        txt = this.gameObject.GetComponent<Text>();
        playerName = "aaa";
        ind = 0;
        isNameSet = false;
        ldrBoard = FindObjectOfType<LeaderboardBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        scoretxt.text = "Score: " + ldrBoard.currentScore.ToString();
        if (ldrBoard.isHighScore())
        {
            getNameFromInput();
            if (ind == 0)
            {
                highlightOne.SetActive(true);
                highlightTwo.SetActive(false);
                highlightThree.SetActive(false);
            }
            else if (ind == 1)
            {
                highlightOne.SetActive(false);
                highlightTwo.SetActive(true);
                highlightThree.SetActive(false);
            }
            else if (ind == 2)
            {
                highlightOne.SetActive(false);
                highlightTwo.SetActive(false);
                highlightThree.SetActive(true);
            }
            else
            {
                highlightOne.SetActive(false);
                highlightTwo.SetActive(false);
                highlightThree.SetActive(false);
            }
        }
        else {
            typeYourName.SetActive(false);
            txt.enabled = false;
            highlightOne.SetActive(false);
            highlightTwo.SetActive(false);
            highlightThree.SetActive(false);
            StartCoroutine(goBackToMenu());
        }
    
    }

    void getNameFromInput()
    {
        if (!isNameSet)
        {

            foreach (char c in Input.inputString)
            {
                if (c == '\b') // has backspace/delete been pressed?
                {
                    if (ind > 0) { ind--; }
                    Debug.Log(ind);
                }
                else if ((c == '\n') || (c == '\r')) // enter/return
                {
                    if (ind < 3) { ind++; }
                    Debug.Log(ind);
                    if (ind == 3)
                    {
                        isNameSet = true;
                        ldrBoard.AddScore(playerName);
                        SceneManager.LoadScene("MainMenu");
                    }
                }

                else //character
                {
                    if (ind == 0)
                    {
                        playerName = c + playerName.Substring(1, 2);
                    }
                    else if (ind == 1)
                    {
                        playerName = playerName[0].ToString() + c + playerName[2].ToString();
                    }
                    else
                    {
                        playerName = playerName[0].ToString() + playerName[1].ToString() + c;
                    }
                }
                txt.text = playerName;

            }
        }
    }

    private IEnumerator goBackToMenu()
    {
       
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("MainMenu");

    }

}
