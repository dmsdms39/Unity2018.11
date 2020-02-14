using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndPanel : MonoBehaviour
{
    public Text ScoreText;
    public Text BestScoreText;

    public GameObject NewImage;

    public GameObject Medal;

    public Sprite Gold_M;
    public Sprite Silver_M;
    public Sprite Bronze_M;

    private void OnEnable() //오브젝트가 켜질때 실행
    {
        //베스트 스코어 갱신
        if(GameManager.score>GameManager.bestScore)
        {
            GameManager.bestScore = GameManager.score;
            NewImage.SetActive(true);
        } else
        {
            NewImage.SetActive(false);
        }

        //스코어 출력
        ScoreText.text = GameManager.score.ToString();
        BestScoreText.text = GameManager.bestScore.ToString();

        if(GameManager.score >= 5)
        {
            Medal.GetComponent<Image>().sprite = Gold_M;
        }
        else if(GameManager.score >= 2)
        {
            Medal.GetComponent<Image>().sprite = Silver_M;
        }
        else
        {
            Medal.GetComponent<Image>().sprite = Bronze_M;
        }
    }

    private void OnDisable() //오브젝트가 꺼질때 실행
    {
        
    }
}
