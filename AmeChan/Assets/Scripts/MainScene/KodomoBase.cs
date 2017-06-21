using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class KodomoBase : MonoBehaviour
{
    public MainScene ms;
    public int hp;
    public GameObject[] hpImages;
    private List<SpriteRenderer> sr;
    public int score;
    // Use this for initialization
    protected void Start()
    {
        ms = GameObject.Find("MainScene").GetComponent<MainScene>();
        hp = 3;

        sr = new List<SpriteRenderer>();
        for (int i = 0; i < hpImages.Length; ++i)
        {
            if (hpImages[i].GetComponent<SpriteRenderer>())
            {
                sr.Add(hpImages[i].GetComponent<SpriteRenderer>());
            }
            hpImages[i].SetActive(false);
        }
        sr.Add(GetComponent<SpriteRenderer>());
    }

    // Update is called once per frame
    protected void Update()
    {
        if (hp <= 0)
        {
            StartCoroutine(GoBackHome());
            

            return;
        }
        for (int i = 0; i < hpImages.Length; ++i)
        {
            hpImages[i].SetActive(false);
        }
        hpImages[hp - 1].SetActive(true);
    }
    IEnumerator GoBackHome()
    {
        // 声を再生

        while (true)
        {
            foreach (var it in sr)
                it.material.color += new Color(0, 0, 0, -0.01f);

            if (sr[0].material.color.a <= 0)
            {
                break;
            }
            else
                yield return null;
        }
        ms.AddCurrentScore(score);
        Destroy(gameObject);
        yield return null;
    }
    private void OnDestroy()
    {
        //print("add score");
    }
}