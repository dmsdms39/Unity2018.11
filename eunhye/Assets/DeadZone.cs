using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    //충돌처리
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (DataManager.Instance.PlayerDie == false)
        {
            if (collision.gameObject.tag.CompareTo("Player") == 0)//플레이어 충돌
            {
                SoundManager.Instance.StopSound("BG");//배경 밖으로 나갔을때 노래멈춤
                DataManager.Instance.PlayerDie = true; //플레이어 죽음
            }
        }
    }
}
