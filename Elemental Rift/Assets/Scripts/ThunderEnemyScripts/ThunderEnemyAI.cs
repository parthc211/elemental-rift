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

    private Animator thunderAnimator;


	void Start ()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        thunderAnimator = GetComponent<Animator>();
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
        //transform.LookAt(target);
        Vector3 relativePos = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos);

        //rotation.x = 0;
        //rotation.z = 0;

        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }

    private void FollowPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, movementSpeed * Time.deltaTime);
    }

    private void ThunderAttack()
    {
        thunderAnimator.SetBool("willAttack", true);
        thunderAnimator.SetBool("isIdle", false);
        GameObject attack = (GameObject)Instantiate(ThunderAttackPrefab);
        attack.transform.position = ThunderAttackSpawnPoint.position;
        attack.transform.rotation = this.transform.rotation;
        Vector3 direction = Player.transform.position - this.transform.position;
        attack.GetComponent<ThunderLightAttack>().SetAttackDirection(direction);
        
    }

    public void SetIsAttackingAnimation()
    {
        thunderAnimator.SetBool("willAttack", false);
        thunderAnimator.SetBool("isAttacking", true);

    }
}
