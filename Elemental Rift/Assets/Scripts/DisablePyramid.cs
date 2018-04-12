using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisablePyramid : MonoBehaviour {

    public GameObject Pyramid;

    public GameObject Obj1;
    public GameObject Obj2;
    public GameObject Obj3;
    public GameObject Obj4;
    public GameObject Obj5;
    public GameObject Obj6;
    public GameObject Obj7;
    public GameObject Obj8;
    public GameObject Obj9;
    public GameObject Obj10;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag=="Player")
        {
            Pyramid.SetActive(false);
            Obj1.SetActive(true);
            Obj2.SetActive(true);
            Obj3.SetActive(true);
            Obj4.SetActive(true);
            Obj5.SetActive(true);
            Obj6.SetActive(true);
            Obj7.SetActive(true);
            Obj8.SetActive(true);
            Obj9.SetActive(true);
            Obj10.SetActive(true);
            gameObject.SetActive(false);
        }
        
    }

}
