using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float moveSpeed = 3f;
    public GameObject ExplosionpreFab;
    public GameObject EnemyBulletPrefab;
    public GameObject ItemPrefab;
    public GameObject Hpbar_Prefab;

    public float currentHp = 4f;
    public float Maxhp;

    private void Start()
    {
        GameObject hpbar = Instantiate(Hpbar_Prefab, gameObject.transform.position, gameObject.transform.rotation);
        hpbar.GetComponent<HP_Bar>().tempOB = gameObject;
        StartCoroutine(Bullet_Co());
    }

    IEnumerator Bullet_Co()
    {
        do
        {
            yield return new WaitForSeconds(Random.Range(0.5f, 2f));
            Instantiate(EnemyBulletPrefab, gameObject.transform.position, gameObject.transform.rotation);
        } while (true);
    }

    private void Update()
    {
        transform.Translate(0, moveSpeed * Time.deltaTime, 0);//,Space.Self 생략 (,Space.World)로 바꾸면 반대
    }

    //충돌체크
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullet") //comeparetag랑 같음
        {
            Destroy(collision.gameObject); //총알이 없어짐
            Damage(collision.gameObject.GetComponent<BulletMove>().power);
       
        }
    }

    //데미지 계산
    public void Damage(float powertemp)
    {
        currentHp -= powertemp;
        if(currentHp<=0)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(ExplosionpreFab, gameObject.transform.position, gameObject.transform.rotation);
        if (Random.Range(0,2) == 0) //2분의1 확률로 아이템 생성(시작점(0), 끝(2)+1)
        {
            Instantiate(ItemPrefab, gameObject.transform.position, gameObject.transform.rotation);
        }
        Destroy(gameObject);
    }
}
