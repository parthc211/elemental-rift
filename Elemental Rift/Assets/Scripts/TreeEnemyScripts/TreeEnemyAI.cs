using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeEnemyAI : MonoBehaviour {

    // Use this for initialization
    private float distanceBewteenPlayer;
    public float minRange = 10.0f;
    private float rotationSpeed = 5.0f;

    private GameObject poisonGasObject;

    private bool poisonActive = false;

    private bool blurrVision = false;
    private float blurrTimer =2.0f;

    public GameObject poisonGasPrefab;
    public Transform poisonSpawnPosition;

    private Transform target;
    public GameObject BlurrGameObject;

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
            //BlurPlayerVision();
        }
        else
        {
            treeAnim.SetBool("isIdle", true);
            if(poisonGasObject != null)
            {
                Destroy(poisonGasObject);
            }

            //Destroy()
            poisonActive = false;

            //Check for blurr timer
            if (blurrVision)
            {
                blurrTimer -= Time.deltaTime;
                if (blurrTimer <= 0)
                {
                    blurrVision = false;
                    blurrTimer = 2.0f;
                    BlurrGameObject.SetActive(false);
                }
            }
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
        poisonGasObject = (GameObject)Instantiate(poisonGasPrefab);
        poisonGasObject.transform.position = poisonSpawnPosition.transform.position;
        
        //Destroy(poison, 5f);
        poisonActive = true;
    }

    public void BlurrPlayerVision()
    {
        blurrVision = true;
        BlurrGameObject.SetActive(true);
    }
}
