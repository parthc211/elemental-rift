using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gateCode : MonoBehaviour {

    public GameObject torch1;
    public GameObject torch2;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(torch1.GetComponent<FlameTorch>().isActive && torch2.GetComponent<FlameTorch>().isActive)
        {
            GetComponent<QuickMover>().isMoving = true;
        }
	}
}
