using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{

    

    [SerializeField]
    private float MaxAttackDistance = 15f;                //Distance within which enemy will start attacking
    private float MinAttackDistance = 10f;
   
    public float EnemySpeed = 0.05f;

    public Transform spawnPosition;
    

    private GameObject Player;
    public GameObject EnemyBulletPrefab;

   


    public Animator enemyAnim;

    private void Awake()
    {
    
    }
    void Start ()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        enemyAnim = GetComponent<Animator>();

    }


    void Update()
    {
        if(Vector3.Distance(Player.transform.position, this.transform.position) < MaxAttackDistance)
        {
            Vector3 direction = Player.transform.position - this.transform.position;
            direction.y = 0;

            //Rotate the enemy in the direction of player
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);

            if(direction.magnitude > MinAttackDistance)
            {
                this.transform.Translate(0, 0, EnemySpeed);
                enemyAnim.SetTrigger("isAttacking");                
                enemyAnim.SetBool("isWalking", true);
                enemyAnim.SetBool("isIdleAttack", false);
                enemyAnim.SetBool("isIdle", false);
                //enemyAnim.SetBool("isKnock", false);
            }
            else
            {
                enemyAnim.SetBool("isIdleAttack", true);
                enemyAnim.SetBool("isWalking", false);
                enemyAnim.SetBool("isIdle", false);
                //enemyAnim.SetBool("isKnock", false);
            }

        }
        else
        {
            enemyAnim.SetBool("isIdle", true);
            enemyAnim.SetBool("isWalking", false);
            enemyAnim.SetBool("isIdleAttack", false);
           // enemyAnim.SetBool("isKnock", false);         
            //enemyAnim.SetBool("isAttack", false);
        }

    }

    public void SpawnBullet()
    {
        GameObject bullet = (GameObject)Instantiate(EnemyBulletPrefab);
        bullet.transform.position = spawnPosition.position;
        Vector3 direction = Player.transform.position - this.transform.position;
        bullet.GetComponent<EnemyBullet>().SetDirection(direction);
    }

    

}
