using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    private float health = 100f;

    [SerializeField]
    private float currHealth = 100f;

	void Start ()
    {
		
	}
	
	
	void Update ()
    {
		
	}

    public void Damage(float amount)
    {
        currHealth -= amount;
        if(currHealth <=0)
        {
            Destroy(gameObject);
        }
    }
}
