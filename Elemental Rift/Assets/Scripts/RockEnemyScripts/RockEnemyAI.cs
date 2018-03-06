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

    public FieldOfView fov;
    public Transform target;

    public float distanceBetweenPlayer;

    public Transform EnemyBulletSpawnPoint;

    public GameObject EnemyBulletPrefab;

    private GameObject Player;
    private float resetWalkTimer;

    private Animator enemyAnim;

    void Start()
    {
        fov = GetComponent<FieldOfView>();
        enemyAnim = GetComponent<Animator>();
        Player = GameObject.FindGameObjectWithTag("Player");

        resetWalkTimer = walkTimer;
    }

    void Update()
    {

        //Find player, return if no player found
        if (fov.visibleTargets.Count == 0)
        {
            enemyAnim.SetBool("isIdle", true);
            return;
        }


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
        else if (distanceBetweenPlayer < minDistance)
        {
            //Debug.Log("Attack PLayer");
            AttackPlayer();
        }

        //Knockback the player if he is in melee range
        if (distanceBetweenPlayer <= meleeRange)
        {
            knockBackPlayer(distanceBetweenPlayer);
        }
        
        
    }

    void LookAtPlayer()
    {
        Vector3 relativePos = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos);

        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }


    void MoveTowardsPlayer(float distBetweenPlayer)
    {      

        if (resetWalkTimer >= 0.0f)
        {
            enemyAnim.SetBool("isWalking", true);
            enemyAnim.SetBool("isIdle", false);
            enemyAnim.SetBool("isAttacking", false);
            enemyAnim.SetBool("isStomp", false);

            transform.position = Vector3.MoveTowards(transform.position, target.position, movementSpeed * Time.deltaTime);

            //Decrement the walktimer every frame the enemy is walking towards the player
            resetWalkTimer -= Time.deltaTime;

            Debug.Log(resetWalkTimer);
        }
        else
        {
            enemyAnim.SetBool("isAttacking", true);
            //enemyAnim.SetTrigger("isAttack");
            enemyAnim.SetBool("isWalking", false);
            enemyAnim.SetBool("isStomp", false);
            enemyAnim.SetBool("isIdle", false);
        }
    }

    void AttackPlayer()
    {
        Debug.Log("Attack Player");
        //attack animation
        enemyAnim.SetBool("isAttacking", true);
        // enemyAnim.SetTrigger("isAttack");
        enemyAnim.SetBool("isIdle", false);
        enemyAnim.SetBool("isWalking", false);
        enemyAnim.SetBool("isStomp", false);

        //trigger event to reset walktimer to 2 seconds once the attack animation is complete
        //walktimer = 2.0f;
    }

    void knockBackPlayer(float distBetweenPlayer)
    {
        /*
		 * Depending on the animation and the reaction on the player we might have to change the if condition
		 * Not sure what it will be, will know more after testing
		 */

            Debug.Log("Knockback Player");
            enemyAnim.SetBool("isStomp", true);
            enemyAnim.SetBool("isWalking", false);
            enemyAnim.SetBool("isAttacking", false);
            enemyAnim.SetBool("isIdle", false);
    }

    public void AttackWithEnemyBullet()
    {
        GameObject bullet = (GameObject)Instantiate(EnemyBulletPrefab);
        bullet.transform.position = EnemyBulletSpawnPoint.position;
        Vector3 direction = Player.transform.position - this.transform.position;
        bullet.GetComponent<EnemyBullet>().SetDirection(direction);
    }

    public void SetWalkTimer()
    {
        Debug.Log("set walk timer");
        resetWalkTimer = walkTimer;
    }
}
