using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float health = 50f;
    private EnemyPatrol patrol;
    public float timer = 3f;
    public bool smallEnemy = true;
    private void Awake()
    {
        patrol = GetComponent<EnemyPatrol>();
    }
    private void Update()
    {
        if(patrol.enabled==false)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                patrol.enabled = true;
                timer = 3f;
            }
                
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(smallEnemy == true)
        {
            if(other.gameObject.tag == "Shield")
            {
                Destroy(gameObject);
            }
        }
    }
    public void TakeDamage()
    {
       
        patrol.enabled = false;

    }
   
}
