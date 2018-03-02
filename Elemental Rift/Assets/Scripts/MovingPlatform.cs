using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MovingPlatform")
        {
            transform.parent = other.transform;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "MovingPlatform")
        {
            transform.parent = null;

        }
    }
    
}
