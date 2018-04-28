using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tut_reflectdmg : MonoBehaviour {

    public GameObject resource_tut;

    float timer;
    bool startTimer = false;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (startTimer)
        {
            timer += Time.deltaTime;
            if(timer > 10.0f)
            {
                resource_tut.SetActive(false);
            }
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        resource_tut.SetActive(true);
        startTimer = true;
    }
}
