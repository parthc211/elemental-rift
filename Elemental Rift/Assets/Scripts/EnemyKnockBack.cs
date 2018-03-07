using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnockBack : MonoBehaviour
{
    [SerializeField]
    //private int Health = 100;                           //Enemy health

    private bool knock = false;
    private float knockTimer = 2f;
    public Collider knockCollider;

    public Animator enemyAnim;

    private EnemyHealth enemyHealth;
	void Start ()
    {
        enemyAnim = GetComponent<Animator>();
        enemyHealth = gameObject.GetComponent<EnemyHealth>();
	}


    void Update()
    {
        if (knock == true && !knockCollider)
        {

            Debug.Log("reset");
            enemyAnim.SetBool("isKnock", false);
            enemyAnim.SetBool("isAttacking", true);
            knock = false;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ShockwaveSpell")
        {
            knock = true;
            knockCollider = other;
            enemyAnim.SetBool("isAttacking", false);
            enemyAnim.SetBool("isKnock", true);
            //enemyAnim.SetBool("isIdle", false);            
            //enemyAnim.SetBool("isWalking", false);

            enemyHealth.TakeDamage(30f);
        }
    }

    
}
