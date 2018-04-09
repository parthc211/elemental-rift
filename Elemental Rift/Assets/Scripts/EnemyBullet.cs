using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

    public float bulletSpeed = 1.2f;
    private Vector3 _direction;

    private GameObject Player;
    public float damageAmount = 25f;
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

        

        if(other.gameObject.tag == "Player")
        {
            other.GetComponent<Player_health>().takedmg(damageAmount);
            Destroy(gameObject);
        }

        if(other.gameObject.tag == "RockEnemy" || other.gameObject.tag == "WaterAura" || other.gameObject.tag == "FireAura" || other.gameObject.tag == "EarthAura")
        {
            return;
        }
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //If enemy bullet collides with the player shield then destroy bullet
        if (collision.gameObject.tag == "IceShield")
        {
            Destroy(gameObject);
            return;
        }
        if (collision.gameObject.tag == "RockEnemy")
        {
            return;
        }
        Destroy(gameObject);
    }
}
