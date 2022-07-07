using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //player 1 score
    [SerializeField] private int P1Score;
    //player 2 score
    [SerializeField] private int P2Score;
    [SerializeField] Scoreboard P1Board;
    [SerializeField] Scoreboard P2Board;

    string scoreUpdate;

    // Start is called before the first frame update
    void Start()
    {
        P1Score = 0;
        P2Score = 0;
    }

    public void P1Scored()
    {
        P1Score++;
        Debug.Log("Player 1 scored! Current Score: " + P1Score);
        scoreUpdate = new string("P1: " + P1Score);
        P1Board.UpdateScore(scoreUpdate);
        if(P1Score == 10)
        {
            Debug.Log("Player 1 wins!");
            Time.timeScale = 0f;
        }
    }

    public void P2Scored()
    {
        P2Score++;
        Debug.Log("Player 2 scored! Current Score: " + P2Score);
        scoreUpdate = new string("P2: " + P2Score);
        P2Board.UpdateScore(scoreUpdate);
        if (P2Score == 10)
        {
            Debug.Log("Player 2 wins!");
            Time.timeScale = 0f;
        }
    }

}
