using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obachan : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GameObject obj = GetClickObject();
        if (obj != null)
        {
            //print(obj.transform.parent.GetComponent<KodomoBase>().hp);

            if (obj.tag == "Atama")
                obj.transform.parent.GetComponent<KodomoBase>().hp-=3;
            if (obj.tag == "Karada")
                if (obj.transform.parent.GetComponent<KodomoBase>())
                    obj.transform.parent.GetComponent<KodomoBase>().hp--;
            else
                    obj.transform.parent.parent.GetComponent<KodomoBase>().hp--;
        }
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
        }
        return result;
    }
}
