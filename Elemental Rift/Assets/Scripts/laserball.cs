using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserball : MonoBehaviour
{

    private float bulletSpeed = 45f;
    private Vector3 _direction;
    private GameObject Player;
    public float damageAmount = 12f;
    Resource_Manager rscMgr;

    // Use this for initialization
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        rscMgr = Player.GetComponent<Resource_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(_direction * bulletSpeed * Time.deltaTime);
        Destroy(gameObject, 1.0f);
    }

    public void SetDirection(Vector3 dir)
    {
        _direction = -dir.normalized;
    }

    private void OnTriggerEnter(Collider other)
    {

        //If enemy bullet collides with the player shield then destroy bullet
        if (other.gameObject.tag == "IceShield")
        {
            if (rscMgr.waterRune >= (damageAmount / 2) && rscMgr.airRune >= (damageAmount / 2))
            {

                rscMgr.waterRune -= (damageAmount / 2);
                rscMgr.airRune -= (damageAmount / 2);

                Destroy(gameObject);

            }
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<Player_health>().takedmg(damageAmount);
            Destroy(gameObject);
        }
    }
}