using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth_Puzzle1 : MonoBehaviour {

    public GameObject leftPane;
    public GameObject rightPane;
    public GameObject lightGlow;
    public GameObject mover;

    bool isActive = false;

    void Start () {
        
    }
	
	
	void Update () {
		
    }

    public void OnRayEnter()
    {
        Debug.Log("Enter");
        leftPane.SetActive(true);
        rightPane.SetActive(true);
        lightGlow.SetActive(true);
        mover.GetComponent<QuickMover>().isMoving = true;
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
