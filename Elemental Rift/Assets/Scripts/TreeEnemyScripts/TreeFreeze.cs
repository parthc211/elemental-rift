using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeFreeze : MonoBehaviour {

    // Use this for initialization
    private bool treeFreeze = false;
    private float freezeTimer = 5f;

    private Animator treeAnim;

   // public Transform freezeSpawnPosition;
    //public GameObject FreezeSpellPrefab;

	void Start ()
    {
        treeAnim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(treeFreeze == true)
        {
            freezeTimer -= Time.deltaTime;
            if (freezeTimer <= 0)
            {
                treeFreeze = false;
                freezeTimer = 5f;
                GetComponent<TreeEnemyAI>().enabled = true;
                treeAnim.enabled = true;

            }
        }
        
	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.gameObject.tag == "FreezeProjectile")
        {
            treeFreeze = true;
            GetComponent<TreeEnemyAI>().enabled = false;
            treeAnim.enabled = false;
        }
    }
}
