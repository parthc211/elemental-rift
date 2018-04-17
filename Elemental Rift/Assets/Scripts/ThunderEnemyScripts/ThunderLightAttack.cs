using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderLightAttack : MonoBehaviour {

    // Use this for initialization
    public float lightAttackSpeed = 2.0f;

    private GameObject Player;
    private Vector3 _direction;


    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        _direction = Player.transform.position - gameObject.transform.position;
        transform.Translate(_direction * lightAttackSpeed * Time.deltaTime);
        Destroy(gameObject, 5f);
    }

    public void SetAttackDirection(Vector3 dir)
    {
        _direction = dir.normalized;
    }
}
