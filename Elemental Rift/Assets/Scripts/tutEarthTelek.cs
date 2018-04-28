using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutEarthTelek : MonoBehaviour {

    public GameObject weld;
    public GameObject fireball;
    public GameObject shield;
    public GameObject freeze;
    public GameObject telek;
    public GameObject earth;

    public GameObject weld_vid;
    public GameObject earthtelek_vid;

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


            weld.SetActive(false);
            fireball.SetActive(false);
            shield.SetActive(false);
            freeze.SetActive(false);
            telek.SetActive(true);
            earth.SetActive(true);
            weld_vid.SetActive(false);
            earthtelek_vid.SetActive(true);
            gameObject.SetActive(false);
        }
    }

}
