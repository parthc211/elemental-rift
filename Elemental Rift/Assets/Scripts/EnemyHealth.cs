using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

    public float health = 100f;

    public Slider healthBar;
    public GameObject deadEnemy;

    private GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        healthBar.maxValue = health;
	}
	
	// Update is called once per frame
	void Update () {
        healthBar.value = health;

        Vector3 target = player.transform.position - gameObject.transform.position;
        Quaternion lookAtPlayer = Quaternion.LookRotation(target);
        healthBar.transform.rotation = lookAtPlayer;

        //CheckDead();
	}

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        CheckDead();
    }

    void CheckDead()
    {
        if(health <= 0)
        {
            GameObject dead = (GameObject)Instantiate(deadEnemy, gameObject.transform.position + Vector3.up * 5, Quaternion.identity);
            Destroy(dead, 3f);
            if (gameObject.GetComponent<DropObject>())
            {
                gameObject.GetComponent<DropObject>().DropObj();
            }
            Destroy(gameObject);

        }
    }
}
