using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movestuff : MonoBehaviour {

	public GameObject toMove;
    public GameObject dest;
    public bool moveIt = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (moveIt == true)
        {
            toMove.transform.position = Vector3.MoveTowards(toMove.transform.position, dest.transform.position, 30 * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            moveIt = true;
        }
    }
}
