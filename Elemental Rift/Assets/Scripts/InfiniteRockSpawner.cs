using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteRockSpawner : MonoBehaviour {

    public GameObject Rock;
    public GameObject BigEnemy;
    bool executeOnce = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
    }


    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player" && executeOnce==false)
        {
            InvokeRepeating("LaunchRocks", 1.0f, 5.0f);
            executeOnce = true ;
        }
        if (collider.gameObject.tag == "BigRock")
        {
            Destroy(collider.gameObject);
        }

    }
    void LaunchRocks()
    {
        Instantiate(Rock, BigEnemy.transform.position, BigEnemy.transform.rotation);
    }

}
