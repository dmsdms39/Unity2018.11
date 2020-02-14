using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static public bool playerdie = false; //한줄

    public float pipeTime = 2f;
    public float pipeMin = -1f;
    public float pipeMax = 1f;

    public GameObject PipePrefab;

    static public int score = 0; //스코어
    static public int bestScore = 0; //최고점수
    public Text ScoreText;

    private void Update()
    {
        ScoreText.text = score.ToString();
    }

    public void Start()
    {
        Time.timeScale = 0;
        GameManager.playerdie = true;
    }//시작안되게 죽은걸로 시작

        IEnumerator PipeStart()
    {
        do
        {
            Instantiate(PipePrefab, new Vector3(2, Random.Range(pipeMin, pipeMax), 0),
                Quaternion.Euler(new Vector3(0, 0, 0)));

            yield return new WaitForSeconds(pipeTime);
        } while (GameManager.playerdie == false);
    }

    public GameObject StartPanel;
    //게임시작버튼
    public void StartBtn()
    {
        GameManager.playerdie = false;
        StartPanel.SetActive(false);
        StartCoroutine(PipeStart());
        Time.timeScale = 1;
    }

    //게임시작버튼
    public void ReStart_Bin()
    {
        GameManager.playerdie = false;
        GameManager.score = 0;
        SceneManager.LoadScene("Play");
    }

}
