using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeEnemyAI : MonoBehaviour {

    // Use this for initialization
    private float distanceBewteenPlayer;
    private float minRange = 10.0f;
    private float rotationSpeed = 5.0f;

    private bool poisonActive = false;

    public GameObject poisonGasPrefab;
    public Transform poisonSpawnPosition;

    private Transform target;

    private Animator treeAnim;

	void Start ()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        treeAnim = GetComponent<Animator>();
        treeAnim.SetBool("isIdle", true);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (target == null)
            return;

        //Distance between Tree Enemy and Player
        distanceBewteenPlayer = Vector3.Distance(target.position, this.transform.position);

        if(distanceBewteenPlayer <= minRange)
        {
            LookPlayer();
            PoisonAttack();
        }
        else
        {
            treeAnim.SetBool("isIdle", true);
            poisonActive = false;
        }
        
	}
    void LookPlayer()
    {
        Vector3 relativePos = transform.position - target.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos);

        rotation.x = 0;
        rotation.z = 0;

        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        
    }

    void PoisonAttack()
    {
        if(!poisonActive)
        {
            treeAnim.SetBool("isAttacking", true);
            treeAnim.SetBool("isIdle", false);
            
        }
        
    }

    public void InstantiatePoisonVFX()
    {
        GameObject poison = (GameObject)Instantiate(poisonGasPrefab);
        poison.transform.position = poisonSpawnPosition.transform.position;
        Destroy(poison, 5f);
        poisonActive = true;
    }
}
