using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearZone : MonoBehaviour
{
    public GameObject gameManager;

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }

    //충돌처리
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (DataManager.Instance.PlayerDie == false)//플레이어 죽으면 실행안됌
        {
            if (collision.gameObject.tag.CompareTo("Player") == 0)//플레이어 충돌
            {
                gameManager.GetComponent<GameManager>().Load_Map();
            }
        }
    }
}
