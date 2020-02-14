using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 10f;

    public GameObject bulletStart; //총알 발사부분
    public GameObject bulletStart2; //총알 발사부분
    public GameObject bulletStart3; //총알 발사부분
    public GameObject ExplosionpreFab;

    public GameObject bulletPrefab; //총알 프리팹

    public float power = 2f;


    private void Update()
    {
        Vector3 min = new Vector3(-2f, -4.5f, 0);//범위 고정
        Vector3 max = new Vector3(2f, 4.5f, 0);

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, min.x, max.x),
            Mathf.Clamp(transform.position.y, min.y, max.y),
            transform.position.z);

        float h = Input.GetAxis("Horizontal"); //가로축 입력받기
        float v = Input.GetAxis("Vertical"); // 세로축 입력받기
        transform.Translate(h * speed * Time.deltaTime, v * speed * Time.deltaTime, 0);

        if (Input.GetKeyDown(KeyCode.Space)) //스페이스 입력시 bulletStart 위치에 총알 생성
        {
            switch (GameManager.PowerLevel)
            {
                case 1:
                    GameObject bullet_Obj = Instantiate(bulletPrefab, bulletStart.transform.position, bulletStart.transform.rotation);
                    bullet_Obj.GetComponent<BulletMove>().power = power;
                    break;
                case 2:
                    GameObject bullet_Obj2 = Instantiate(bulletPrefab, bulletStart2.transform.position, bulletStart2.transform.rotation);
                    bullet_Obj2.GetComponent<BulletMove>().power = power;
                    GameObject bullet_Obj3 = Instantiate(bulletPrefab, bulletStart3.transform.position, bulletStart3.transform.rotation);
                    bullet_Obj3.GetComponent<BulletMove>().power = power;
                    break;
                default:
                    GameObject bullet_Obj4 = Instantiate(bulletPrefab, bulletStart.transform.position, bulletStart.transform.rotation);
                    bullet_Obj4.GetComponent<BulletMove>().power = power;
                    GameObject bullet_Obj5 = Instantiate(bulletPrefab, bulletStart2.transform.position, bulletStart2.transform.rotation);
                    bullet_Obj5.GetComponent<BulletMove>().power = power;
                    GameObject bullet_Obj6 = Instantiate(bulletPrefab, bulletStart3.transform.position, bulletStart3.transform.rotation);
                    bullet_Obj6.GetComponent<BulletMove>().power = power;
                    break;

            }
        }
    }
    //충돌체크
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Die();
        }

        if (collision.gameObject.tag == "EnemyBullet")
        {
            Destroy(collision.gameObject);
            Die();
        }

        if (collision.gameObject.tag == "Item")
        {
            Destroy(collision.gameObject);
            GameManager.PowerLevel += 1;
            GameManager.PowerTime = 10f;
        }
    }


    void Die()
    {
        Instantiate(ExplosionpreFab, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
    }
}
