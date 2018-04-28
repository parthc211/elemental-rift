using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tut_weld : MonoBehaviour {

    public GameObject weld;
    public GameObject fireball;
    public GameObject shield;
    public GameObject freeze;
    public GameObject telek;
    public GameObject earth;

    public GameObject spellwheel_vid;
    public GameObject weld_vid;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {


            weld.SetActive(true);
            fireball.SetActive(false);
            shield.SetActive(false);
            freeze.SetActive(false);
            telek.SetActive(false);
            earth.SetActive(false);
            spellwheel_vid.SetActive(false);
            weld_vid.SetActive(true);
            gameObject.SetActive(false);

        }
    }
}
