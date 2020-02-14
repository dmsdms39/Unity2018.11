using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMove : MonoBehaviour
{
    public float PipeMoveSpeed=2f;
    private void Update()
    {
        if (GameManager.playerdie == false)
        {
            transform.Translate(-PipeMoveSpeed * Time.deltaTime, 0, 0);

            if (gameObject.transform.position.x <= -5f)
            {
                Destroy(gameObject);
            }
        }

    }

}
