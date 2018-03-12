using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock_1_Puzzle : MonoBehaviour {

    public GameObject lock1;
    private bool canMove = false;
    public bool needPlayer = false;
    public GameObject highlight;
	// Use this for initialization
	void Start () {
        highlight.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		if(lock1.GetComponent<LocknKeyPuzzle>().isActive == true)
        {
            canMove = true;
            highlight.SetActive(true);
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
