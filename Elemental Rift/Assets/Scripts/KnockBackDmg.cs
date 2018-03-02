using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBackDmg : MonoBehaviour {

    public float radius = 4.0f;

    private Transform transform;
    private Vector3 location;
    private Collider[] objectsInRange;
    // Use this for initialization
    void Start () {
        transform = GetComponent<Transform>();
       
        location = transform.position;
      

        objectsInRange = Physics.OverlapSphere(location, radius);
        foreach (Collider col in objectsInRange)
        {
            if (col.CompareTag("Player"))
            {
                col.gameObject.GetComponent<Player_health>().takedmg(40f);
            }

            

            Destroy(gameObject, 1.0f);
        }
    }

	// Update is called once per frame
	void Update () {
        
	}

}
