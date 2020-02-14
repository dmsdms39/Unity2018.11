using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject player;
    //public float CoinMoveSpeed = 10f;//코인이 붙는 속도

    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");//플레이어 찾기
        float distance = Vector2.Distance(gameObject.transform.position, player.transform.position);//거리를 계산
       
        //코인과 플레이어 가까우면 자석 활성화
        if (DataManager.Instance.PlayerDie == false && DataManager.Instance.MargnetTimeCurrent >0)
        {
            if (distance < DataManager.Instance.ItemDistance)
            {
                Vector2 dir = player.transform.position - transform.position;//코인 방향을 설정
                transform.Translate(dir.normalized * DataManager.Instance.ItemSpeed * Time.deltaTime, Space.World);//방향으로 코인 이동
            }
        }
    }

    //충돌처리
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (DataManager.Instance.PlayerDie == false)//플레이어 죽으면 코인 충돌 안됌
        {
            if (collision.gameObject.tag.CompareTo("Player") == 0)//플레이어 충돌
            {
                SoundManager.Instance.PlaySound("Coin");
                DataManager.Instance.score += 1;
                gameObject.SetActive(false);//코인을 끈다.
            }
        }
    }
}
