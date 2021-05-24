using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


// 기둥 통과할때마다 점수 100 씩 증가
// 새가 죽으면 게임 종료  UI 표시
public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public Text scoreUI;
    Text highScoreText;
    int highScore; //최고점수 저장. 게임시작되면 초기화, 게임 중 점수 넘기면 ui와 함께 갱신
    bool isGameOver; //>> 기본값 false

    static public GameManager instace;


    int HighScore
    {
        set
        {
            highScore = value;
            if (highScoreText == null)
                highScoreText = GameObject.Find("Canvas").transform.Find("HighScore").GetComponent<Text>();
            highScoreText.text = $"High Score : {highScore.ToNumber()}";
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }
    }
    private void Awake()
    {
        instace = this;
        gameOverUI.SetActive(false);
        int highScore = PlayerPrefs.GetInt("HighScore");
        HighScore = highScore; //속성

    }

    //함수
    void SetHighScore(int _highScore)
    {
        highScore = score;
        highScoreText.text = $"High Score : {highScore.ToNumber()}";
        PlayerPrefs.SetInt("HighScore", highScore);
        PlayerPrefs.Save();
    }

    internal void SetGameOver()
    {
        isGameOver = true;
        ShowGameOver(true);
    }
    private void Update()
    {
        if(isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                // 게임 재시작
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            }
        }
        
    }

    internal void ShowGameOver(bool active)
    {
        gameOverUI.SetActive(active);
    }

    int score;
    public float scrollSpeedXMultiply = 1;

    internal void AddScore()
    {
        score += 100;
        scoreUI.text = "Score : " + score;

        if (score > highScore)
        {
            HighScore = score;

        }
    }

    
}
