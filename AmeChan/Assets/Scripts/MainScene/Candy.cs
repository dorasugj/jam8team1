using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : MonoBehaviour
{
    public GameObject hitPointObject;
    public Vector3 destination;
    Vector3 direction;
    // Use this for initialization
    void Start()
    {
        //direction = destination - transform.position;
        //direction.Normalize();
        iTween.MoveTo(gameObject, iTween.Hash("position", destination,"easetype",iTween.EaseType.linear, "oncompletetarget",gameObject, "oncomplete","DestroyThis"));
    }

    // Update is called once per frame
    void Update()
    {
        
        //if(transform.position != destination)
        //transform.position += direction;
    }

    void DestroyThis()
    {
        if (hitPointObject != null)
        {
            //print(obj.transform.parent.GetComponent<KodomoBase>().hp);

            if (hitPointObject.tag == "Atama")
                hitPointObject.transform.parent.GetComponent<KodomoBase>().hp -= 3;
            if (hitPointObject.tag == "Karada")
                if (hitPointObject.transform.parent.GetComponent<KodomoBase>())
                    hitPointObject.transform.parent.GetComponent<KodomoBase>().hp--;
                else
                    hitPointObject.transform.parent.parent.GetComponent<KodomoBase>().hp--;
        }
        Destroy(gameObject);
    }
}
