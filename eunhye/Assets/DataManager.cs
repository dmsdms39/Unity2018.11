using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    static DataManager instance;

    public static DataManager Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            DestroyObject(gameObject);
        }
    }

    public bool PlayerDie = false; //플레이어 살아있음
    public int score = 0; //점수

    public float playTimeCurrent = 20f;
    public float playtimeMax = 20f;//20초 최대

    public float MargnetTimeCurrent = 5f; //작동중인 시간
    public float MargnetTimeMax = 5f; //효과 시간기준

    public float ItemSpeed = 15f;
    public float ItemDistance = 3.5f;

    public int stage = 0;
    public int stageView = 0;

}
