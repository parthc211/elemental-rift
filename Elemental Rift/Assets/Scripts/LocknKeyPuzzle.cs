using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocknKeyPuzzle : MonoBehaviour {

    public GameObject key;

    private string keyTag;

    public bool isActive;
	// Use this for initialization
	void Start () {
        keyTag = key.tag;
        isActive = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == keyTag)
        {
            isActive = true;
        }
    }
}
