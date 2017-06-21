using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obachan : MonoBehaviour {
    public Sprite[] Candies;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        GetClickObject();
        //if (obj != null)
        //{
        //    //print(obj.transform.parent.GetComponent<KodomoBase>().hp);

        //    if (obj.tag == "Atama")
        //        obj.transform.parent.GetComponent<KodomoBase>().hp-=3;
        //    if (obj.tag == "Karada")
        //        if (obj.transform.parent.GetComponent<KodomoBase>())
        //            obj.transform.parent.GetComponent<KodomoBase>().hp--;
        //    else
        //            obj.transform.parent.parent.GetComponent<KodomoBase>().hp--;
        //}
	}
    private GameObject GetClickObject()
    {
        GameObject result = null;
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D collition2d = Physics2D.OverlapPoint(tapPoint);
            if (collition2d)
            {
                result = collition2d.transform.gameObject;
            }

            GameObject go = new GameObject();
            go.transform.localScale = new Vector3(0.1f, 0.1f);
            go.transform.position = transform.Find("ThrowPoint").transform.position;

            var sr = go.AddComponent<SpriteRenderer>();
            sr.sprite = Candies[0];

            var candy = go.AddComponent<Candy>();
            candy.destination = tapPoint;
            if(result)
            candy.hitPointObject = result.transform.gameObject;


        }
        return result;
    }
}
