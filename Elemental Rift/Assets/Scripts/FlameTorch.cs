using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameTorch : MonoBehaviour {

    public GameObject flamelight;
    public GameObject flame;

    public bool isActive;
	// Use this for initialization
	void Start () {
		if(flame.activeInHierarchy && flamelight.activeInHierarchy)
        {
            isActive = true;
        }
        else
        {
            isActive = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "FreezeProjectile" && isActive == true)
        {

            flamelight.SetActive(false);
            flame.SetActive(false);
            isActive = false;
        }

        if (other.gameObject.tag == "weld" && isActive == false)
        {

            flamelight.SetActive(true);
            flame.SetActive(true);
            isActive = true;
        }

    }
}
