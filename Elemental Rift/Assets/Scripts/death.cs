﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            collision.transform.gameObject.GetComponent<Player_health>().takedmg(101f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            other.transform.gameObject.GetComponent<Player_health>().takedmg(101f);
        }
    }
}