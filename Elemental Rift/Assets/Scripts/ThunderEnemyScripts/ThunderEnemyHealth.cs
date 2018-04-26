using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderEnemyHealth : MonoBehaviour {

    // Use this for initialization
    public float thunderHealth = 100f;

	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    public void TakeDamage(float damageAmount)
    {
        thunderHealth -= damageAmount;
    }

    //TODO: enemy death
}
