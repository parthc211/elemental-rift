using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weldObj : MonoBehaviour {

    public GameObject welded;
    public GameObject unwelded;
    bool weld;

    DestoyMe dm;
	// Use this for initialization
	void Start () {

        foreach(Transform child in transform)
        {
            if (child.tag == "Welded")
            {
                weld = true;
                
            }
            if (child.tag == "Unwelded")
            {
                weld = false;
                
            }
        }

    }

    private void Awake()
    {
        
    }
    // Update is called once per frame
    void Update ()
    {
        
    }

    public void switchGO()
    {
        if(weld == true)
        {
            //welded.SetActive(false);
            //unwelded.SetActive(true);
            dm = gameObject.GetComponentInChildren<DestoyMe>();
            dm.destroy();
            Instantiate(unwelded, gameObject.transform);

            weld = false;
            return;
        }

        if (weld == false)
        {
            //unwelded.SetActive(false);
            //welded.SetActive(true);
            dm = gameObject.GetComponentInChildren<DestoyMe>();
            dm.destroy();
            Instantiate(welded, gameObject.transform);
            weld = true;
            return;
        }
    }
}
