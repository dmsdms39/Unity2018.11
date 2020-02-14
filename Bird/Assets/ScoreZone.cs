using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    //충돌처리
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag.CompareTo("Player")==0) //Player 판단
        {
            GameManager.score += 1; //점수올리기
            //GameManager.score = GameManager.score + 1;
        }
    }


}
