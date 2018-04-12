using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTarget : MonoBehaviour {

    public bool isActive = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void OnRayEnter()
    {
        Debug.Log("Enter");
    }

    public void OnRayStay()
    {
        Debug.Log("Stay");
    }

    public void OnRayExit()
    {
        Debug.Log("Exit");
    }
}
