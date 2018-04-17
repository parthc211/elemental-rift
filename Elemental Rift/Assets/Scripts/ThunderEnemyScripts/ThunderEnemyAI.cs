using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderEnemyAI : MonoBehaviour
{
    public float movementSpeed = 10.0f;
    private float rotationSpeed = 5.0f;
    public float minRange = 5.0f;
    public float maxRange = 10.0f;

    public Transform target;
    private GameObject Player;
    public GameObject ThunderAttackPrefab;
    public Transform ThunderAttackSpawnPoint;


	void Start ()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
	}
	
	
	void Update ()
    {
        if (target == null)
            return;

        //Distance between Thunder Enemy and Player
        float distanceBetweenPlayer;
        distanceBetweenPlayer = Vector3.Distance(target.position, transform.position);


        //Attack the player if within minimum range
        if(distanceBetweenPlayer <= minRange)
        {
            LookPlayer();
            ThunderAttack();
        }
        //Follow and Attack the player if between min and max range
        else if(distanceBetweenPlayer > minRange && distanceBetweenPlayer <= maxRange)
        {
            LookPlayer();
            FollowPlayer();
            ThunderAttack();
        }

	}
    private void LookPlayer()
    {
        transform.LookAt(target);
    }

    private void FollowPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, movementSpeed * Time.deltaTime);
    }

    private void ThunderAttack()
    {
        GameObject attack = (GameObject)Instantiate(ThunderAttackPrefab);
        attack.transform.position = ThunderAttackSpawnPoint.position;
        Vector3 direction = Player.transform.position - this.transform.position;
        attack.GetComponent<ThunderLightAttack>().SetAttackDirection(direction);
        
    }
}
