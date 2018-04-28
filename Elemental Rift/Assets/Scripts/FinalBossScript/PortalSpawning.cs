using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalSpawning : MonoBehaviour {

    //public GameObject Portal;
    //public Transform sp;
    //private Vector3 SpawnPoint;

    
    // Use this for initialization
    void Start ()
    {
        //SpawnPoint = new Vector3(-180f, 100f, 681f);
        //Portal = GameObject.FindWithTag("Portal");

    }

    // Update is called once per frame
    void Update () {

 
    }

    //void OnTriggerEnter(Collider col)
    //{
    //    if (col.gameObject.tag == "Player")
    //    {
    //        GameObject portal = Instantiate(Portal, SpawnPoint, Quaternion.identity);
    //        //portal.transform.position = SpawnPoint.position;

    //        //Destroy(gameObject);
    //    }
    //}
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Collected Crystal");
            StaticVariablesWaterPuzzle.crystalDestroyed = true;

            //GameObject portal = Instantiate(Portal, SpawnPoint, Quaternion.identity);
            //portal.transform.position = SpawnPoint.position;
            //Portal.SetActive(true);
            Destroy(gameObject);
        }

    }
}
