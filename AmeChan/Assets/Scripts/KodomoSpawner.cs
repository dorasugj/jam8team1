using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;

public class KodomoSpawner : MonoBehaviour {
    public float spawnSpan;
    GameObject kodomoNormal;
    GameObject kodomoBycycle;


	// Use this for initialization
	void Start () {
        kodomoNormal = Resources.Load("Prefabs/KodomoNormal") as GameObject;
        kodomoBycycle = Resources.Load("Prefabs/KodomoBycycle") as GameObject;

        Observable.Interval(TimeSpan.FromSeconds(spawnSpan))
                        .Subscribe(_ => SpawnKodomoNormal());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void SpawnKodomoNormal()
    {
        var wid = UnityEngine.Random.Range(-8, 8);
        var hei = UnityEngine.Random.Range(0, 5);
        Instantiate(kodomoNormal, new Vector3(wid, hei, 1),Quaternion.identity);

    }
}
