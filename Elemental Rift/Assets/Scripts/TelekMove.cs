using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelekMove : MonoBehaviour {

    public GameObject pointA;
    public GameObject pointB;

    private Vector3 pA;
    private Vector3 pB;

    public bool telek = true;
	// Use this for initialization
	void Start () {
        pA = pointA.transform.position;
        pB = pointB.transform.position;
        //pA = transform.position;
       // pB = transform.position + new Vector3(10.0f, 0.0f, 0.0f);
	}
	
	// Update is called once per frame
	void Update () {
        float speed = 4.0f * Time.deltaTime;
        if(telek == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, pA, speed);
        }

        if (telek == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, pB, speed);
        }
    }

    public void move()
    {
        

        if (telek == true)
        {
            telek = false;
            
            return;
        }

        if (telek == false)
        {
            telek = true;
           
            return;
        }
    }
}
