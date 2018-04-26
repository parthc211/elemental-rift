using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyCamController : MonoBehaviour {


    public GameObject FlyCam;
    public GameObject Player;
    public GameObject Canvas;


	void Start () {


    }

    void Update() {


        if (FlyCam.GetComponent<Transform>().position.x > 584 && FlyCam.GetComponent<Transform>().position.x < 588 &&
           FlyCam.GetComponent<Transform>().position.y > 159 && FlyCam.GetComponent<Transform>().position.y < 163 &&
           FlyCam.GetComponent<Transform>().position.z > 457 && FlyCam.GetComponent<Transform>().position.z < 460)
        {
            //Debug.Log("Flycam Reached");
            Player.SetActive(true);
            FlyCam.SetActive(false);
            Canvas.SetActive(true);
        }
    
		
	}
}
