using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class freezeobj : MonoBehaviour {

    bool isActive = true;
    float timer = 0.0f;

    public GameObject go1;
    public GameObject go2;
    public GameObject go3;
    public GameObject go4;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(isActive == false)
        {
            timer += Time.deltaTime;
            if(timer >= 5.0f)
            {
                go1.SetActive(true);
                go2.SetActive(true);
                go3.SetActive(true);
                go4.SetActive(true);
                isActive = true;
                timer = 0;
            }
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "FreezeProjectile")
        {
            go1.SetActive(false);
            go2.SetActive(false);
            go3.SetActive(false);
            go4.SetActive(false);
            isActive = false;
        }
    }
}
