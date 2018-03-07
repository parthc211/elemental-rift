using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weldObj : MonoBehaviour {

    public GameObject welded;
    public GameObject broken;
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
            weld = false;
            Instantiate(unwelded, gameObject.transform);

           
            return;
        }

        if (weld == false)
        {
            //unwelded.SetActive(false);
            //welded.SetActive(true);
            dm = gameObject.GetComponentInChildren<DestoyMe>();
            dm.destroy();
            weld = true;
            Instantiate(welded, gameObject.transform);
            
            return;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(weld == false)
        {
            if(other.tag == "Player")
            {
                dm = gameObject.GetComponentInChildren<DestoyMe>();
                dm.destroy();
                Instantiate(broken, gameObject.transform);
                Invoke("CreateUnwelded", 3.0f);
            }
        }
    }

    void CreateUnwelded()
    {
        Instantiate(unwelded, gameObject.transform);
        weld = false;
    }
}
