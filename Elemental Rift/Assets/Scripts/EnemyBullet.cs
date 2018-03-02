using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

    private float bulletSpeed = 1.2f;
    private Vector3 _direction;

    private GameObject Player;
    private float damageAmount = 15f;
    bool getDir = true;
    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

        //_direction = Player.transform.position - gameObject.transform.position;
    }

    void Start ()
    {
		
	}
	

	void Update ()
    {
        if(getDir == true)
        {
            _direction = Player.transform.position - gameObject.transform.position;
            getDir = false;
        }
        
        transform.Translate(_direction * bulletSpeed * Time.deltaTime);
        Destroy(gameObject, 5f);
	}

    public void SetDirection(Vector3 dir)
    {
        _direction = dir.normalized;
    }

    private void OnTriggerEnter(Collider other)
    {

        //If enemy bullet collides with the player shield then destroy bullet
        if(other.gameObject.tag == "IceShield")
        {
            Destroy(gameObject);
        }

        if(other.gameObject.tag == "Player")
        {
            other.GetComponent<Player_health>().takedmg(damageAmount);
            Destroy(gameObject);
        }

        if(other.gameObject.tag == "RockEnemy")
        {
            return;
        }
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "RockEnemy")
        {
            return;
        }
        Destroy(gameObject);
    }
}
