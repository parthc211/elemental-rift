using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock_1_Puzzle : MonoBehaviour {

    public GameObject lock1;
    private bool canMove = false;
    public bool needPlayer = false;
    public Color changeCol;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(lock1.GetComponent<LocknKeyPuzzle>().isActive == true)
        {
            canMove = true;
            if (needPlayer == false)
            {
                gameObject.GetComponent<QuickMover>().isMoving = true;
            }
            else
            {
                gameObject.GetComponent<Material>().color = Color.Lerp(Color.grey, Color.black, Mathf.PingPong(Time.time, 1)); 
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
