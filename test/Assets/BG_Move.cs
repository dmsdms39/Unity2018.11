using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_Move : MonoBehaviour
{
    public float moveSpeed= 1f;

    private void Update()
    {
        if(transform.position.y < -10)
        {
            transform.position = new Vector3(0, 9, 0);
        }

        transform.Translate(0, -moveSpeed * Time.deltaTime, 0);
    }

}
