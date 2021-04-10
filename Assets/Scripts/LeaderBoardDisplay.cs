using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoardDisplay : MonoBehaviour
{
    [SerializeField] int rank;
    [SerializeField] bool isScore;
    LeaderboardBehaviour ldrBoard;
    Text txt;
    // Start is called before the first frame update
    void Update()
    {
        ldrBoard = FindObjectOfType<LeaderboardBehaviour>();

        txt = this.gameObject.GetComponent<Text>();
        if (isScore)
        {
            txt.text = ldrBoard.getScore(rank-1);
        }
        else
        {
            txt.text = ldrBoard.getName(rank - 1);
        }
    }

}
