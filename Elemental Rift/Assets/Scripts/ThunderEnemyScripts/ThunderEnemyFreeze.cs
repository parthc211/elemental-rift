using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderEnemyFreeze : MonoBehaviour {

    // Use this for initialization
    private bool thunderFreeze = false;
    private float freezeTimer = 5f;
    private float resetFreezeTimer = 5f;

    private Animator thunderAnim;

	void Start ()
    {
        thunderAnim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(thunderFreeze)
        {
            freezeTimer -= Time.deltaTime;
            if(freezeTimer <= 0)
            {
                thunderFreeze = false;
                freezeTimer = resetFreezeTimer;
                GetComponent<ThunderEnemyAI>().enabled = true;
                thunderAnim.enabled = true;
            }
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "FreezeProjectile")
        {
            thunderFreeze = true;
            GetComponent<ThunderEnemyAI>().enabled = false;
            thunderAnim.enabled = false;
        }
    }
}
