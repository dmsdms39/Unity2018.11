using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP_Bar : MonoBehaviour
{
    public Image Bar;
    public GameObject tempOB;

    private void Awake()
    {
        this.GetComponent<Transform>().SetParent(GameObject.Find("HUD").GetComponent<Transform>());//자식으로 들어감
    }

    private void Update()
    {
        if(tempOB == null)
        {
            Destroy(gameObject);//적이 죽었을때 없앰
        } else
        {
            Bar.fillAmount = tempOB.GetComponent<EnemyMove>().currentHp / tempOB.GetComponent<EnemyMove>().Maxhp;
            //남은 체력 표시
        }
    }

    private void LateUpdate()
    {
        if (tempOB != null)
        {
            gameObject.transform.position =
                Camera.main.WorldToScreenPoint(tempOB.transform.position + new Vector3(0, 0.7f, 0));// 적 바로 위에 표시
        }

    }
}
