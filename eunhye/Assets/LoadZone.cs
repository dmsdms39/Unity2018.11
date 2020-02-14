using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadZone : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject LoadMap;

    //충돌처리
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(DataManager.Instance.PlayerDie == false)
        {
            if(collision.gameObject.tag.CompareTo("Player")==0)
            {
                //다음 스테이지 불러오기
                gameManager.GetComponent<GameManager>().Next_Stage();

                //로드맵 3초 뒤 끄기
                Invoke("Close", 3f);
            }
        }
    }
    void Close()
    {
        LoadMap.SetActive(false);//로드맵 비활성화
    }

}
