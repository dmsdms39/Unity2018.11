using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float speed = 10f;
    public float power = 1;

    private void Start()
    {
        Destroy(gameObject, 2f);    
    }

    private void Update()
    {
        transform.Translate(0, 1 * speed * Time.deltaTime, 0);
    }
}
