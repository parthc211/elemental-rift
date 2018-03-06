using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnockBack : MonoBehaviour
{
    [SerializeField]
    //private int Health = 100;                           //Enemy health

    private bool knock = false;
    private float knockTimer = 2f;

    public Animator enemyAnim;

    private EnemyHealth enemyHealth;
	void Start ()
    {
        enemyAnim = GetComponent<Animator>();
        enemyHealth = gameObject.GetComponent<EnemyHealth>();
	}
	

	void Update ()
    {
        //if(knock == true)
        //{
        //    knockTimer -= Time.deltaTime;
        //    if(knockTimer<=0)
        //    {
        //        enemyAnim.SetBool("isKnock", false);
        //        enemyAnim.SetBool("isAttacking", true);
        //       // enemyAnim.SetBool("isIdle", true);
        //        //enemyAnim.SetBool("isWalking", true);
        //        knockTimer = 2f;
        //        knock = false;
        //    }
           
        //}
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "KnockSpell")
        {
            //knock = true;
            enemyAnim.SetBool("isAttacking", false);
            enemyAnim.SetBool("isKnock", true);
            //enemyAnim.SetBool("isIdle", false);            
            //enemyAnim.SetBool("isWalking", false);

            enemyHealth.TakeDamage(30f);
        }
    }
}
