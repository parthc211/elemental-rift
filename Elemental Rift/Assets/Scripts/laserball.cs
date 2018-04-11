using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserball : MonoBehaviour
{

    private float bulletSpeed = 45f;
    private Vector3 _direction;

    // Use this for initialization
    void Start()
    {

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
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<Player_health>().takedmg(12);
            Destroy(gameObject);
        }
    }
}