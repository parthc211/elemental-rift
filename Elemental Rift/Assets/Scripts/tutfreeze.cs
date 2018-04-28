using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutfreeze : MonoBehaviour {

    public GameObject weld;
    public GameObject fireball;
    public GameObject shield;
    public GameObject freeze;
    public GameObject telek;
    public GameObject earth;

    
    public GameObject earthtelek_vid;
    public GameObject freeze_vid;
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


            weld.SetActive(true);
            fireball.SetActive(false);
            shield.SetActive(false);
            freeze.SetActive(true);
            telek.SetActive(true);
            earth.SetActive(true);
            earthtelek_vid.SetActive(false);
            freeze_vid.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
