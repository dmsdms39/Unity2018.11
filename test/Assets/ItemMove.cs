using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMove : MonoBehaviour
{
    public float moveSpeed = 2f;
    Vector3 target;

    private void Start()
    {
        TargetSetting();
        Destroy(gameObject, 5f);//5초 뒤에 삭제
    }

    public void TargetSetting()
    {
        target = new Vector3(Random.Range(-2f, 2f), Random.Range(-4f,4f),0);
    }

    private void Update()
    {
        float dis = Vector2.Distance(gameObject.transform.position, target);
        if(dis>0.2f)
        {
            Vector2 dir = target - transform.position;
            transform.Translate(dir.normalized * moveSpeed * Time.deltaTime, Space.World);
        }
        else
        {
            TargetSetting();
        }
    }
}
