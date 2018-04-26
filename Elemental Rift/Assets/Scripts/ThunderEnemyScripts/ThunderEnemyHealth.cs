using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThunderEnemyHealth : MonoBehaviour {

    // Use this for initialization
    public float thunderHealth = 100f;

    public Slider healthBar;

    private GameObject player;

	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        healthBar.maxValue = thunderHealth;
	}
	
	// Update is called once per frame
	void Update ()
    {
        healthBar.value = thunderHealth;

        Vector3 target = player.transform.position - gameObject.transform.position;
        Quaternion lookAtPlayer = Quaternion.LookRotation(target);
        healthBar.transform.rotation = lookAtPlayer;
	}

    public void TakeDamage(float damageAmount)
    {
        thunderHealth -= damageAmount;
    }

    //TODO: enemy death
}
