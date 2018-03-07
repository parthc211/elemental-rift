using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockEnemyAI : MonoBehaviour
{

    public float rotationSpeed = 5.0f;
    public float minDistance = 5.0f;
    public float movementSpeed = 2.0f;
    public float meleeRange = 1.0f;
    public float walkTimer = 2.0f;
    public float health = 50f;
    public float stompTimer = 5.0f;
    public float attackTimer = 2.0f;

    public FieldOfView fov;
    public Transform target;

    public float distanceBetweenPlayer;

    public Transform EnemyBulletSpawnPoint;

    public GameObject EnemyBulletPrefab;

    private GameObject Player;
    private RockEnemyPatrol enemyPatrol;
    private float resetWalkTimer;
    private float resetStompTimer;
    public float resetAttackTimer;

    private Animator enemyAnim;

    void Start()
    {
        fov = GetComponent<FieldOfView>();
        enemyAnim = GetComponent<Animator>();
        Player = GameObject.FindGameObjectWithTag("Player");
        enemyPatrol = GetComponent<RockEnemyPatrol>();

        resetWalkTimer = walkTimer;
        resetStompTimer = 0.0f;
        resetAttackTimer = 0.0f;
    }

    void Update()
    {

        //Find player, return if no player found
        if (fov.visibleTargets.Count == 0)
        {
            //enemyAnim.SetBool("isIdle", true);
            //return;
            enemyPatrol.Patrol();
            
        }
        else
        {
            target = fov.visibleTargets[0];

            //Redundancy check for player
            if (target == null)
                return;

            //Distance between Enemy and player
            distanceBetweenPlayer = Vector3.Distance(target.position, transform.position);

            //Face the player
            LookAtPlayer();


            if (distanceBetweenPlayer >= minDistance)
            {
                MoveTowardsPlayer(distanceBetweenPlayer);
            }
            else if (distanceBetweenPlayer < minDistance && distanceBetweenPlayer > meleeRange)
            {
                AttackPlayer();
            }

            //Knockback the player if he is in melee range
            else if (distanceBetweenPlayer <= meleeRange)
            {
                KnockBackPlayer(distanceBetweenPlayer);
            }
        }
    }

    void LookAtPlayer()
    {
        Vector3 relativePos = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos);

        rotation.x = 0;
        rotation.z = 0;

        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }


    void MoveTowardsPlayer(float distBetweenPlayer)
    {
        if (resetWalkTimer >= 0.0f)
        {
            enemyAnim.SetBool("isWalking", true);
            enemyAnim.SetBool("isIdle", false);
            enemyAnim.SetBool("isAttacking", false);
            //enemyAnim.SetBool("isStomp", false);

            transform.position = Vector3.MoveTowards(transform.position, target.position, movementSpeed * Time.deltaTime);

            //Decrement the walktimer every frame the enemy is walking towards the player
            resetWalkTimer -= Time.deltaTime;
        }
        else
        {
            enemyAnim.SetBool("isAttacking", true);
            //enemyAnim.SetTrigger("isAttack");
            enemyAnim.SetBool("isWalking", false);
            //enemyAnim.SetBool("isStomp", false);
            enemyAnim.SetBool("isIdle", false);
        }
    }

    void AttackPlayer()
    {
        if (resetAttackTimer <= 0.0f)
        {
            //attack animation
            enemyAnim.SetBool("isAttacking", true);
            // enemyAnim.SetTrigger("isAttack");
            enemyAnim.SetBool("isIdle", false);
            enemyAnim.SetBool("isWalking", false);
            //enemyAnim.SetBool("isStomp", false);

            //trigger event to reset walktimer to 2 seconds once the attack animation is complete
            //walktimer = 2.0f;
        }
        else
        {
            enemyAnim.SetBool("isAttacking", false);
            enemyAnim.SetBool("isIdle", true);
            enemyAnim.SetBool("isWalking", false);
            resetAttackTimer -= Time.deltaTime;
        }
    }

    void KnockBackPlayer(float distBetweenPlayer)
    {
        /*
		 * Depending on the animation and the reaction on the player we might have to change the if condition
		 * Not sure what it will be, will know more after testing
		 */

        if (resetStompTimer <= 0.0f)
        {
            Debug.Log("Knockback Player");

            // enemyAnim.SetBool("isStomp", true);
            enemyAnim.SetTrigger("isStomp");
            enemyAnim.SetBool("isWalking", false);
            enemyAnim.SetBool("isAttacking", false);
            enemyAnim.SetBool("isIdle", false);
            
            //Player.GetComponent<Player_health>().takedmg(1);
        }
        else
        {
            enemyAnim.ResetTrigger("isStomp");
            enemyAnim.SetBool("isWalking", false);
            enemyAnim.SetBool("isAttacking", false);
			enemyAnim.SetBool("isIdle", true);

            resetStompTimer -= Time.deltaTime;
        }
    }

    public void AttackWithEnemyBullet()
    {
        GameObject bullet = (GameObject)Instantiate(EnemyBulletPrefab);
        bullet.transform.position = EnemyBulletSpawnPoint.position;
        Vector3 direction = Player.transform.position - this.transform.position;
        bullet.GetComponent<EnemyBullet>().SetDirection(direction);
    }


    //Change the name of the function to something like setTimer
    public void SetWalkTimer()
    {
		Debug.Log ("animation Event");
        resetWalkTimer = walkTimer;
        resetAttackTimer = attackTimer;
    }

    public void StompPlayer()
    {
        //TODO: Change damage after testing
        Debug.Log("Stomp Player");
        Player.GetComponent<Player_health>().takedmg(1);
    }

    public void SetStompTimer()
    {
        Debug.Log("Reset Stomp Timer");
        resetStompTimer = stompTimer;
    }
}