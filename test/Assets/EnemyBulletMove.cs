using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletMove : MonoBehaviour
{
    public float speed = 10f;

    private void Start()
    {
        Destroy(gameObject, 2f);
    }

    private void Update()
    {
        transform.Translate(0, 1 * speed * Time.deltaTime, 0);
    }
}
