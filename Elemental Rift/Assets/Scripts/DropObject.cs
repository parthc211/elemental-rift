using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropObject : MonoBehaviour {

    public GameObject dropObj;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DropObj()
    {
        GameObject objectDrop = (GameObject)Instantiate(dropObj, gameObject.transform.position + Vector3.up * 4, Quaternion.identity);
    }
}
