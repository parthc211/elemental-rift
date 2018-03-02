using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSystem : MonoBehaviour {

   
    public int TheDamage = 50;                     //Damage to the Enemy
    public float Distance;
    public float MaxDistance = 3f;               //Max distance within which you can shoot

    private GameObject Enemy;

    private bool playerShield = false;
    private float shieldTimer = 5f;

    private bool knockBack = false;
    private float knockBackTimer = 5f;

    public float colliderIncrease = 300f;

    public Transform SpawnPoint;

    public GameObject FreezeSpellPrefab;
    public GameObject FreezeProjectilePrefab;
    public GameObject IceShieldPrefab;
    public GameObject KnockBackPrefab;
    public GameObject WeldPrefab;


   

	void Start ()
    {
        Enemy = GameObject.FindGameObjectWithTag("Enemy");
        
    }
	
	
	void Update ()
    {

        //Freeze attack
        if (Input.GetMouseButtonDown(0))
        {
            Freeze(); 
        }

        //IceShield
        if (Input.GetKeyDown(KeyCode.Alpha1) && playerShield == false)
        {
            IceShield();
        }

        //Reset the shield timer
        if(playerShield == true)
        {
            shieldTimer -= Time.deltaTime;
            if(shieldTimer<=0)
            {
                playerShield = false;
                shieldTimer = 5f;
            }
        }


        //KnockBack
        if(Input.GetKeyDown(KeyCode.Alpha2) && knockBack == false)
        {
            KnockBack();
        }

        //Reset the knockback timer
        if(knockBack == true)
        {
            knockBackTimer -= Time.deltaTime;
            if(knockBackTimer<=0)
            {
                knockBack = false;
                knockBackTimer = 5f;
            }
        }

        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            Weld();
        }
	}

    void Freeze()
    {

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {

            GameObject projectile = Instantiate(FreezeProjectilePrefab, SpawnPoint.position, transform.rotation);
            Destroy(projectile, 1f);


            //Distance = hit.distance;
            //if (Distance < MaxDistance)
            //{
            //    //hit.transform.SendMessage("ApplyDamage", TheDamage, SendMessageOptions.DontRequireReceiver);
            //    //If the target is enemy            


            //}
        }

    }

    void IceShield()
    {
        playerShield = true;
        Vector3 spawnPosition = transform.forward;
        GameObject shield = Instantiate(IceShieldPrefab, spawnPosition, transform.rotation);
        shield.transform.SetParent(this.gameObject.transform);
        Destroy(shield, 5f);
    }

    void KnockBack()
    {
        knockBack = true;

        GameObject knock = Instantiate(KnockBackPrefab);
        SphereCollider knockSphereCollider = knock.GetComponentInChildren<SphereCollider>();

        knock.transform.position = transform.position;

        knockSphereCollider.enabled = true;
        knockSphereCollider.radius += colliderIncrease * Time.deltaTime;
        Destroy(knock, 5f);

    }

    void Weld()
    {
        GameObject weld = Instantiate(WeldPrefab, SpawnPoint.position, transform.rotation);
        Destroy(weld, 3f);
    }

    
}
