using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainScene : MonoBehaviour {

    private int currentScore;
    public Text currentScoreText;
    public Text highScoreText;
    public Text timeText;
    public Text finishText;
    public Text countdownText;
    public Image imageMask;

    public bool isStarted;
    public bool isGameOver;
    public float time;
	// Use this for initialization
	void Start () {
        currentScoreText.gameObject.SetActive(false);
        highScoreText.gameObject.SetActive(false);

    timeText.gameObject.SetActive(false);
        finishText.gameObject.SetActive(false);
        currentScore = 0;
        isStarted = false;
        isGameOver = false;
        time = 30;
        countdownText.text = "";

        StartCoroutine(CountdownCoroutine());
	}
	
	// Update is called once per frame
	void Update () {
        if (!isStarted)
            return;

        if (isGameOver)
        {
            finishText.gameObject.SetActive(true);
            currentScoreText.gameObject.SetActive(false);
            highScoreText.gameObject.SetActive(false);

            SceneManager.LoadScene("Result");
            return;
        }
        else
        {
            timeText.text = time.ToString("F0");
            currentScoreText.text = "Score : " + currentScore;
        }
    }

    IEnumerator Timer()
    {
        isStarted = true;
        currentScoreText.gameObject.SetActive(true);
        highScoreText.gameObject.SetActive(true);
        highScoreText.text = "HighScore : " + PlayerPrefs.GetInt("RANK0",0).ToString();


        timeText.gameObject.SetActive(true);
        while (true)
        {
            if (time >= 0)
            {
                time -= Time.deltaTime;
                if (time < 5)
                    currentScoreText.gameObject.SetActive(false);
            }
            else
                isGameOver = true;


            yield return null;
        }
    }
    IEnumerator CountdownCoroutine()
    {
        imageMask.gameObject.SetActive(true);
        countdownText.gameObject.SetActive(true);

        countdownText.text = "3";
        yield return new WaitForSeconds(1.0f);

        countdownText.text = "2";
        yield return new WaitForSeconds(1.0f);

        countdownText.text = "1";
        yield return new WaitForSeconds(1.0f);

        countdownText.text = "GO!";
        yield return new WaitForSeconds(1.0f);

        countdownText.text = "";
        countdownText.gameObject.SetActive(false);
        imageMask.gameObject.SetActive(false);
        PlayerPrefs.SetInt("TEMP_SCORE", 0);

        StartCoroutine(Timer());

    }
    public int GetCurrentScore()
    { return currentScore; }
    public void AddCurrentScore(int score)
    {
        currentScore += score;
        PlayerPrefs.SetInt("TEMP_SCORE", PlayerPrefs.GetInt("TEMP_SCORE", 0)+10);
        print(PlayerPrefs.GetInt("TEMP_SCORE",0));
        PlayerPrefs.Save();
    }
}
