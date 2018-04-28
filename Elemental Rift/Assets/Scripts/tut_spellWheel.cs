using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tut_spellWheel : MonoBehaviour {

    public GameObject spellwheel_vid;
   
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {


            spellwheel_vid.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
