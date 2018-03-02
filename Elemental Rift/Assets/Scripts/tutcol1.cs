using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutcol1 : MonoBehaviour {

    public GameObject hide1;
    public GameObject hide2;
    public GameObject show1;
    public GameObject show2;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(gameObject.tag != "TutClick")
        {
            if (other.tag == "Player")
            {

                tut();
                gameObject.SetActive(false);
            }
        }
    }

    public void tut()
    {
        show1.SetActive(true);
        show2.SetActive(true);
        hide1.SetActive(false);
        hide2.SetActive(false);
    }
}
