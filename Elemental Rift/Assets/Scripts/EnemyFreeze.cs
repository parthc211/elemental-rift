using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFreeze : MonoBehaviour
{

    private bool enemyFreeze = false;
    private float freezeTimer = 5f;


    private SkinnedMeshRenderer enemySkinMesh;
    private Material[] EnemyNormalMaterial;
    [SerializeField]
    private Material[] EnemyFreezeMaterial;

    public Transform freezeSpawn;

    public GameObject FreezeSpellPrefab;

    private Animator enemyAnim;

    private void Awake()
    {
        enemySkinMesh = GetComponentInChildren<SkinnedMeshRenderer>();
        EnemyNormalMaterial = enemySkinMesh.materials;
        enemyAnim = GetComponent<Animator>();
    }

    void Start ()
    {
		
	}
	

	void Update ()
    {
        if(enemyFreeze == true)
        {
            freezeTimer -= Time.deltaTime;
            if(freezeTimer <= 0)
            {
                enemyFreeze = false;
                freezeTimer = 5f;                
                GetComponent<RockEnemyAI>().enabled = true;
                enemyAnim.enabled = true;
            }
        }
		
	}

    public void ChangeToFreezeMat()
    {
        enemyFreeze = true;
        //GetComponent<Renderer>().material = EnemyFreezeMaterial;
        enemySkinMesh.materials = EnemyFreezeMaterial;
        GetComponent<EnemyLogic>().enabled = false;
        enemyAnim.SetBool("Idle", true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "FreezeProjectile")
        {
            //Destroy(other.gameObject);
            //GameObject freeze = Instantiate(FreezeSpellPrefab, freezeSpawn.position, Quaternion.identity);
            enemyFreeze = true;
            GetComponent<RockEnemyAI>().enabled = false;
            enemyAnim.enabled = false;
           // Destroy(freeze, 5f);

        }
    }
}
