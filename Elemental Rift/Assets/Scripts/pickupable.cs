using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupable : MonoBehaviour {

    public GameObject telekEffect;
	// Use this for initialization
	void Start () {
        telekEffect.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
       
    }

    public void TelekEffectOn()
    {
        telekEffect.SetActive(true);
    }

    public void TelekEffectOff()
    {
        telekEffect.SetActive(false);
    }
}
