using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endzone : MonoBehaviour
{
    [SerializeField] Paddle P1;
    [SerializeField] Paddle P2;
    [SerializeField] Ball ball;
    [SerializeField] GameManager gManager;
    
    public enum EndzoneId { P1_Zone, P2_Zone};

    public EndzoneId endzoneId = new EndzoneId();

    public void UpdateScore()
    {
        if(endzoneId == EndzoneId.P1_Zone)
        {
            
            //reset the ball and paddles
            //increment player 2 score by 1
            gManager.P2Scored();
            P1.ResetPosition();
            P2.ResetPosition();
            ball.ResetPos();
        }
        else if(endzoneId == EndzoneId.P2_Zone)
        {
            
            //increment Player One score by 1
            //reset the ball and paddels
            gManager.P1Scored();
            P1.ResetPosition();
            P2.ResetPosition();
            ball.ResetPos();
        }
    }
}
