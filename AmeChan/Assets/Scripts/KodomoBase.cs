using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class KodomoBase : MonoBehaviour
{
    public int hp;
    public GameObject[] hpImages;
    private List<SpriteRenderer> sr;
    // Use this for initialization
    protected void Start()
    {
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
            print(hp);
        }
        hpImages[hp - 1].SetActive(true);
    }

    IEnumerator GoBackHome()
    {
        // 声を再生

        while(true)
        {
            foreach(var it in sr)
            it.material.color += new Color(0, 0, 0, -0.01f);

            if (sr[0].material.color.a <= 0)
            {
                Destroy(gameObject);
                yield return null;
            }
            else
                yield return null;
        }
    }
}
