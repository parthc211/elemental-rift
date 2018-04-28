using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteTwoScript : MonoBehaviour {


    public GameObject torch1;
    public GameObject torch2;

    bool torch1_lit;
    bool torch2_lit;

    bool torch1_extinguished;
    bool torch2_extinguished;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(torch1.GetComponent<FlameTorch>().isActive)
        {
            torch1_lit = true;
            Debug.Log("t1 lit");
        }

        if (torch2.GetComponent<FlameTorch>().isActive)
        {
            torch2_lit = true;
            Debug.Log("t2 lit");
        }

        if (torch1_lit && !torch1.GetComponent<FlameTorch>().isActive)
        {
            torch1_extinguished = true;
            Debug.Log("t1 n");
        }

        if (torch2_lit && !torch2.GetComponent<FlameTorch>().isActive)
        {
            torch2_extinguished = true;
            Debug.Log("t2 n");
        }

        if (torch1_extinguished && torch2_extinguished)
        {
            GetComponent<QuickDoor>().openDoor = true;
            Debug.Log("Done");
        }
		
	}
}
