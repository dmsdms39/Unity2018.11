using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text ScoreText; //스코어 표시할곳
    public Image TimeBar;//시간표시 바

    public GameObject[] StageMap;//맵 여러개를 담을 공간
    public GameObject LoadMap;
    public Text StageText;//화면에 공간만들기

    public GameObject BG_1;
    public GameObject BG_2;

    public GameObject EndPanel;

    public GameObject[] Number_Image;
    public Sprite[] Number;


    //스테이지 올리는 함수
    public void Next_Stage()
    {
        if(BG_1.activeSelf ==false)
        {
            BG_1.SetActive(true);
            BG_2.SetActive(false);
        }
        else
        {
            BG_1.SetActive(false);
            BG_2.SetActive(true);
        }
        DataManager.Instance.stage += 1;
        DataManager.Instance.stageView += 1;

        if(DataManager.Instance.stage> StageMap.Length)
        {
            DataManager.Instance.stage = DataManager.Instance.stage % StageMap.Length;
            if(DataManager.Instance.stage == 0)
            {
                DataManager.Instance.stage = StageMap.Length;
            }
        }
        StageStart();//스테이지 시작 함수
    }

    //스테이지 시작하는 함수
    public void StageStart()
    {
        for (int temp = 1; temp <= StageMap.Length; temp++)
        {
            if (temp == DataManager.Instance.stage)
            {
                StageMap[temp - 1].transform.position = new Vector3(15f, 
                    StageMap[temp - 1].transform.position.y,
                    StageMap[temp - 1].transform.position.z);
                StageMap[temp - 1].SetActive(true);
            }
            else
            {
                StageMap[temp - 1].SetActive(false);
            }
        }
    }

    public void Load_Map()
    {
        LoadMap.transform.position = new Vector3(15f,
            LoadMap.transform.position.y, LoadMap.transform.position.z);
        LoadMap.SetActive(true);
    }

    private void Update()
    {
        if(DataManager.Instance.stageView == 0)
        {
            StageText.text = "시작";
        }
        else
        {
            StageText.text = "Stage " + DataManager.Instance.stageView.ToString();
        }

        if (DataManager.Instance.PlayerDie == false)//플레이어 죽으면 Time 안줄음
        {
            DataManager.Instance.playTimeCurrent -= 1 * Time.deltaTime;
            TimeBar.fillAmount = DataManager.Instance.playTimeCurrent / DataManager.Instance.playtimeMax;//그래프 그리기

            //시간이 다되면 노래종료
            if (DataManager.Instance.playTimeCurrent <= 0)
            {
                SoundManager.Instance.StopSound("BG");
                DataManager.Instance.PlayerDie = true;
            }

            //자석아이템 시간줄이기
            if(DataManager.Instance.MargnetTimeCurrent > 0)
            {
                DataManager.Instance.MargnetTimeCurrent -= 1 * Time.deltaTime;
            }
        }     

        if(DataManager.Instance.PlayerDie == true)
        {
            EndPanel.SetActive(true);//죽으면 end panel 열기
        }

        //점수띄우기
        int temp = DataManager.Instance.score / 10000;
        Number_Image[0].GetComponent<Image>().sprite = Number[temp];

        int temp2 = DataManager.Instance.score % 10000;
        temp2 = temp2 / 1000;
        Number_Image[1].GetComponent<Image>().sprite = Number[temp2];

        int temp3 = DataManager.Instance.score % 1000;
        temp3 = temp3 / 100;
        Number_Image[2].GetComponent<Image>().sprite = Number[temp3];

        int temp4 = DataManager.Instance.score % 100;
        temp4 = temp4 / 10;
        Number_Image[3].GetComponent<Image>().sprite = Number[temp4];

        int temp5 = DataManager.Instance.score % 10;
        Number_Image[4].GetComponent<Image>().sprite = Number[temp5];

        //ScoreText.text = DataManager.Instance.score.ToString("n0"); //스코어표시
    }

    //다시시작 버튼
    public void ReStart_Btn()
    {
        DataManager.Instance.stage = 0;
        DataManager.Instance.stageView = 0;
        DataManager.Instance.score = 0;
        DataManager.Instance.PlayerDie = false;
        DataManager.Instance.playTimeCurrent = DataManager.Instance.playtimeMax;
        DataManager.Instance.MargnetTimeCurrent = 0;

        SceneManager.LoadScene("SampleScene");
    }
}
