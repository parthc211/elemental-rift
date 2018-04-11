using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelekDmg : MonoBehaviour {

    public GameObject rubble;
    public float damage = 0;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "RockEnemy")
        {
            if (damage != 0)
            {


                collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
                Instantiate(rubble, gameObject.transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
