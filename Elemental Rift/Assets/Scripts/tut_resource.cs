using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tut_resource : MonoBehaviour {


    public GameObject resource_tut;

    float timer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if(timer > 2.0f && timer < 14.0f)
        {
            resource_tut.SetActive(true);
        }
        else
        {
            resource_tut.SetActive(false);
        }
	}
}
