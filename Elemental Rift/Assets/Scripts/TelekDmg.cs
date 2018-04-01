using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelekDmg : MonoBehaviour {

    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "RockEnemy")
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(10);
            Destroy(gameObject);
        }
    }
}
