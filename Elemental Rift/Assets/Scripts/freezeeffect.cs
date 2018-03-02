using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class freezeeffect : MonoBehaviour {

    public GameObject FreezeSpellPrefab;

    private GameObject parentObj;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            return;
        }

        //if (other.gameObject.tag == "RockEnemy")
        //{
        //    return;
        //}


        GameObject freezeeffect = Instantiate(FreezeSpellPrefab, gameObject.transform.position, Quaternion.identity);
        Destroy(freezeeffect, 5f);
        Destroy(gameObject);
    }
}
