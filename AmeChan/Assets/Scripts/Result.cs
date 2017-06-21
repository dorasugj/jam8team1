using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Result : MonoBehaviour {
    private enum MODE{
        COUNT,
        WAIT,
        NAME_ENTRY,
        TOUCH,
    }
    private MODE mode;

    //外部リソース
    public Text scoreText;
    public Animator touch;
    public Text rankInText;
    public Text nameEntryText;
    public Text[] inputNameText;
    public GameObject nameMarker;
    public GameObject[] button;
    public AudioSource audioSource;
    public AudioClip[] audioClip;

    private int score;
    private int viewScore;
    private int[] scoreList = new int[4];
    private int nowRank;
    private float startTime;

    //ネームエントリー用
    private int selectNum;
    private int decidedNum;
    private string[] nameList = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "X", ".", " ", "←", "→", "㍉" };

	// Use this for initialization
	void Start () {
        for (int i = 0; i < 3; i++)
        {
            scoreList[i] = PlayerPrefs.GetInt("RANK" + i);
        }
        score = PlayerPrefs.GetInt("TEMP_SCORE");
        startTime = Time.time;

        audioSource.PlayOneShot(audioClip[0]);
    }
	
	// Update is called once per frame
	void Update () {
        if (mode == MODE.COUNT)
        {
            if(Time.time-startTime > 0.01f)
            {
                if (viewScore < score) {
                    viewScore++;
                    scoreText.text = viewScore.ToString();
                    startTime = Time.time;
                }
                else
                {
                    mode=MODE.WAIT;
                    startTime = Time.time;
                    audioSource.Stop();
                    audioSource.PlayOneShot(audioClip[1]);
                }
            }
        }
        else if (mode == MODE.WAIT)
        {
            if(Time.time-startTime > 2.0f)
            {
                //ランクインしてるかどうか確認
                if (scoreList[2] < score)
                {
                    //ソート
                    for (int i = 2; i > -1 && scoreList[i] < score; i--)
                    {
                        scoreList[i + 1] = scoreList[i];
                        scoreList[i] = score;
                        nowRank = i;
                    }

                    rankInText.enabled = true;
                    nameEntryText.enabled = true;
                    nameMarker.SetActive(true);
                    for (int i = 0; i < inputNameText.Length; i++) inputNameText[i].enabled = true;
                    for (int i = 0; i < button.Length; i++) button[i].SetActive(true);

                    mode = MODE.NAME_ENTRY;
                }
                else
                {
                    touch.enabled = true;
                    mode = MODE.TOUCH;
                }

                audioSource.Play();
            }
        }
        else if (mode == MODE.NAME_ENTRY)
        {

        }
        else if (mode == MODE.TOUCH)
        {
            if (Input.GetMouseButton(0))
            {
                for (int i = 0; i < 3; i++) PlayerPrefs.SetInt("RANK" + i, scoreList[i]);
                SceneManager.LoadScene("Ranking");
            }
        }

        //デバッグ用
        //if (Input.GetKeyDown(KeyCode.Return))
        //{
        //    for (int i = 0; i < 3; i++) PlayerPrefs.SetInt("RANK" + i, 0);
        //}
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    PlayerPrefs.SetInt("RANK0", 100);
        //    PlayerPrefs.SetInt("RANK1", 50);
        //    PlayerPrefs.SetInt("RANK2", 30);
        //    PlayerPrefs.SetInt("TEMP_SCORE", 200);
        //}
    }

    public void PushLeftButton()
    {
        selectNum = (selectNum + 30) % 31;
        nameEntryText.text = nameList[selectNum];
    }

    public void PushNameEntryButton()
    {
        if (selectNum < 28)
        {
            inputNameText[decidedNum].text = nameList[selectNum];
            decidedNum++;
        }
        else if (selectNum < 29) //←
        {
            if (decidedNum > 0) decidedNum--;
        }
        else if (selectNum < 30) //→
        {
            if (decidedNum < 2) decidedNum++;
        }

        nameMarker.transform.localPosition = new Vector3(-100.0f + 100.0f * decidedNum, -120.0f, 0.0f);

        if (decidedNum == 3 || selectNum == 30)
        {
            for (int i = 0; i < 3; i++) PlayerPrefs.SetInt("RANK" + i, scoreList[i]);
            PlayerPrefs.SetString("NAME" + nowRank, inputNameText[0].text + inputNameText[1].text + inputNameText[2].text);
            SceneManager.LoadScene("Ranking");
        }
    }

    public void PushRightButton()
    {
        selectNum = (selectNum + 1) % 31;
        nameEntryText.text = nameList[selectNum];
    }
}
