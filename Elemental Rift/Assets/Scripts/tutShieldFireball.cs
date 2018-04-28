using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutShieldFireball : MonoBehaviour {

    public GameObject weld;
    public GameObject fireball;
    public GameObject shield;
    public GameObject freeze;
    public GameObject telek;
    public GameObject earth;
   
    public GameObject freeze_vid;
    public GameObject shieldfb_vid;
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
            fireball.SetActive(true);
            shield.SetActive(true);
            freeze.SetActive(true);
            telek.SetActive(true);
            earth.SetActive(true);
            freeze_vid.SetActive(false);
            shieldfb_vid.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
