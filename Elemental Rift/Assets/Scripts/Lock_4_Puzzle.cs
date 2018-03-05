﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock_4_Puzzle : MonoBehaviour {

    public GameObject lock1;
    public GameObject lock2;
    public GameObject lock3;
    public GameObject lock4;

    private bool canMove = false;
    public bool needPlayer = false;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        if (lock1.GetComponent<LocknKeyPuzzle>().isActive == true && lock2.GetComponent<LocknKeyPuzzle>().isActive == true 
                && lock3.GetComponent<LocknKeyPuzzle>().isActive == true && lock4.GetComponent<LocknKeyPuzzle>().isActive == true)
        {
            canMove = true;
            if (needPlayer == false)
            {
                gameObject.GetComponent<QuickMover>().isMoving = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (needPlayer == true)
        {

            if (canMove == true)
            {

                if (other.tag == "Player")
                {
                    gameObject.GetComponent<QuickMover>().isMoving = true;
                }

            }
        }
    }
}