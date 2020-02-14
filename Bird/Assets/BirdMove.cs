using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMove : MonoBehaviour
{
    public GameObject EndPanel;
    public float birdJump = 0.5f;

    private void Update()
    {
        if (GameManager.playerdie == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector3(0, birdJump, 0);
                transform.rotation = Quaternion.Euler(0, 0, 25f);
            }
            transform.Rotate(0, 0, -1f);
        }
    }

    //충돌처리
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.CompareTo("pipe") == 0)
        {
            GameManager.playerdie = true;
            EndPanel.SetActive(true);
        }
    }
}
