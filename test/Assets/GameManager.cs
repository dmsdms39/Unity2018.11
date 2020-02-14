using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public bool PlayerDie = false;
    static public int PowerLevel = 1;
    static public float PowerTime = 10f;

    public GameObject EnemyPrefab;

    private void Start()
    {
        StartCoroutine(EnemyStart_Co());
    }

    private void Update()
    {
        if(PowerTime != 1)
        {
            PowerTime -= 1 * Time.deltaTime;
            if(PowerTime <= 0)
            {
                PowerTime -= 1;
                PowerTime = 10f;
            }
        }
    }

    IEnumerator EnemyStart_Co()
    {
        do
        {
            Instantiate(EnemyPrefab, new Vector3(Random.Range(-2f, 2f), 5, 0),
                Quaternion.Euler(0, 0, 180));

            yield return new WaitForSeconds(Random.Range(1f, 3f));

        } while (PlayerDie == false);
    }
}
