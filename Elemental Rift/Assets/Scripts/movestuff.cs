using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movestuff : MonoBehaviour {

	public GameObject lock1;
    public GameObject dest;
    //public bool moveIt = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (lock1.GetComponent<LocknKeyPuzzle>().isActive == true)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, dest.transform.position, 30 * Time.deltaTime);
        }
    }

}
