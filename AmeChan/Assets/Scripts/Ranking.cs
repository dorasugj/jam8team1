using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ranking : MonoBehaviour {
    public Text[] scoreText;
    public Text[] nameText;

	// Use this for initialization
	void Start () {
        for (int i = 0; i < 3; i++)
        {
            scoreText[i].text = PlayerPrefs.GetInt("RANK" + i, 0).ToString();
            nameText[i].text = PlayerPrefs.GetString("NAME" + i, "AAA").ToString();
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PushReturnTitleButton()
    {
        SceneManager.LoadScene("Title");
    }

    public void PushReturnGameButton()
    {
        SceneManager.LoadScene("Main");
    }
}
