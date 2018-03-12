using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocknKeyPuzzle : MonoBehaviour {

    public GameObject key;

    private string keyTag;

    public bool isActive;

    public GameObject flames;
	// Use this for initialization
	void Start () {
        keyTag = key.tag;
        isActive = false;
        flames.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == keyTag)
        {
            isActive = true;
            flames.gameObject.SetActive(true);
            Destroy(other.gameObject);
        }
    }
}
