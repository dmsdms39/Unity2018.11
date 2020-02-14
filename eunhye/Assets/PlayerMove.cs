using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public float jump = 10f;
    public float jump2 = 12f;

    int jumpCount = 0;
    //점프버튼
    public void Jump_Btn()
    {
        if (DataManager.Instance.PlayerDie == false)//플레이어 죽으면 점프안됌
        {
            SoundManager.Instance.PlaySound("Jump");
            if (jumpCount == 0) //점프를 한번도 안함
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, jump, 0);
                jumpCount += 1;
            }
            else if (jumpCount == 1)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, jump2, 0);
                jumpCount += 2;
            }
        }
    }

    //충돌처리
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.CompareTo("Land") == 0) //바닥에 닿으면
        {
            jumpCount = 0;
        }

        if (collision.gameObject.tag.CompareTo("Block") == 0) //장애물에 닿으면
        {
            DataManager.Instance.playTimeCurrent -= 3f;
        }
    }
}
