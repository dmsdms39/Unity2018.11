using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMove : MonoBehaviour
{
    public float mapSpeed = 10f;

    public GameObject[] ItemSet;//아이템 모으는곳

    private void OnEnable() //켜질때마다 실행
    {
        for(int temp = 0; temp < ItemSet.Length; temp++)
        {
            ItemSet[temp].SetActive(true);
        }
    }

    private void Update()
    {
        if (DataManager.Instance.PlayerDie == false)//플레이어 죽으면 맵안움직임
        {
            transform.Translate(-mapSpeed * Time.deltaTime, 0, 0);
        }
    }

}
