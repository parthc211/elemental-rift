using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	public float rotationSpeed = 5.0f;
	public float minDistance = 5.0f;
	public float movementSpeed = 2.0f;
	public float meleeRange = 1.0f;

	public FieldOfView fov;
	public Transform target;

	public float distanceBetweenPlayer;

    private Animator enemyAnim;

    public Transform SpawnPoint;
    public GameObject EnemyBulletPrefab;

    public GameObject Player;

    public float attackTime = 4f;
    private bool isAttack = false;
    private float timer = 0.0f;

    public AnimationClip stomp;
    public GameObject stompColider;
    public Transform stompLoc;
    public GameObject stompEffect;
	void Start ()
	{
		fov = GetComponent<FieldOfView> ();
        enemyAnim = GetComponent<Animator>();
        //Player = GameObject.FindGameObjectWithTag("Player");

        //AnimationEvent animationEvent = new AnimationEvent();
        //animationEvent.functionName = stomp();
        //animationEvent.floatParameter = "single type parameter you want to pass"
        //animationEvent.time = "time when to trigger event"
        //Animation["state you wish to add event"].clip.AddEvent(animationEvent);
    }


	void Update ()
	{
        timer += Time.deltaTime;
        if (timer >= 3f)
        {
            isAttack = true;
        }
        else
        {
            isAttack = false;
            enemyAnim.SetBool("isStomp", false);
            //enemyAnim.SetBool("isIdleAttack", false);
        }

        if (fov.visibleTargets.Count == 0)
        {
            enemyAnim.SetBool("isIdle", true);
            enemyAnim.SetBool("isWalking", false);
            return;
        }

		target = fov.visibleTargets[0];

		if (target == null)
			return;

       
        

		distanceBetweenPlayer = Vector3.Distance (target.position, transform.position);

        LookAtPlayer();
        MoveTowardsPlayer (distanceBetweenPlayer);
        
        //Attack Player animation
        //knockBackPlayer(distanceBetweenPlayer);
    }

	void LookAtPlayer ()
	{
		Vector3 relativePos = target.position - transform.position;
		Quaternion rotation = Quaternion.LookRotation (relativePos);

        //Debug.Log(rotation);

        transform.LookAt(target.position);

        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }

	void MoveTowardsPlayer (float distBetweenPlayer)
	{

		if (distBetweenPlayer >= minDistance)
		{
           
            enemyAnim.SetBool("isWalking", true);
            enemyAnim.SetBool("isIdle", false);
            if(isAttack == true)
            {
                Debug.Log("High");
                enemyAnim.SetTrigger("isAttacking");
                timer = 0.0f;
            }
            enemyAnim.SetBool("isIdleAttack", false);
            enemyAnim.SetBool("isStomp", false);
			transform.position = Vector3.MoveTowards (transform.position, target.position, movementSpeed * Time.deltaTime);
		}
        else
        if(distanceBetweenPlayer < minDistance && distBetweenPlayer > meleeRange)
        {
            
            enemyAnim.SetBool("isWalking", false);
            enemyAnim.SetBool("isIdle", false);
            //enemyAnim.SetBool("isIdleAttack", true);
            if (isAttack == true)
            {
                Debug.Log("Mid");
                enemyAnim.SetBool("isIdleAttack", true);
                enemyAnim.SetTrigger("isAttacking");
                timer = 0.0f;
                
            }
            //enemyAnim.SetTrigger("isAttacking");
            enemyAnim.SetBool("isStomp", false);
           // transform.position = gameObject.transform.position;

        }
        else
        if (distBetweenPlayer <= meleeRange)
        {

            //Melee
            enemyAnim.SetBool("isIdleAttack", false);
            enemyAnim.SetBool("isWalking", false);
            enemyAnim.SetBool("isIdle", false);
            if (isAttack == true)
            {
                Debug.Log("Knockback Player");
                enemyAnim.SetBool("isStomp", true);
                isAttack = false;
                timer = 0.0f;
                StartCoroutine(Stomp());
            }
            


            //Add Player Damage
        }
    }

    IEnumerator Stomp()
    {
        
        yield return new WaitForSeconds(stomp.length);
        //print("Yassss");
        Instantiate(stompColider, stompLoc.position, Quaternion.identity);
        GameObject stompeffect = (GameObject)Instantiate(stompEffect, stompLoc.position, Quaternion.identity);
        Destroy(stompeffect, 1.5f);
    }
    void knockBackPlayer (float distBetweenPlayer)
	{
		if (distBetweenPlayer <= meleeRange)
		{
            //Melee
			Debug.Log ("Knockback Player");
            enemyAnim.SetBool("isStomp", true);
            enemyAnim.SetBool("isIdleAttack", false);
            enemyAnim.SetBool("isWalking", false);
           

            //Add Player Damage
		}
	}

    public void Attack()
    {
        GameObject bullet = (GameObject)Instantiate(EnemyBulletPrefab, SpawnPoint.position, Quaternion.identity);
        //bullet.transform.position = SpawnPoint.position;
        //Vector3 direction = Player.transform.position - gameObject.transform.position;
        //bullet.GetComponent<EnemyBullet>().SetDirection(direction);
    }
}
