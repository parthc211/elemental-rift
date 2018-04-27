using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThunderEnemyHealth : MonoBehaviour {

    // Use this for initialization
    public float thunderHealth = 100f;

    public Slider healthBar;

    private GameObject player;
    public Transform[] allChildren;

    public float delayEffectsTimer = 2.0f;

    public Transform thunderDeadVFXSpawnPoint;
    public GameObject ThunderDeadVFXPrefab;
    public GameObject ThunderAfterDeadVFXPrefab;

    public GameObject CrystralPrefab;

    public SkinnedMeshRenderer bodySkinMesh;
    public SkinnedMeshRenderer wingsSkinMesh;
    public SkinnedMeshRenderer badgeSkinMesh;
    public Material[] bodyDamageMaterials;
    public Material[] wingsDamageMaterials;
    public Material badgeDamageMaterial;

    private bool crystalSpawned;

	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        healthBar.maxValue = thunderHealth;
        //allChildren = GetComponentsInChildren<Transform>();
        crystalSpawned = false;

    }
	
	// Update is called once per frame
	void Update ()
    {
        healthBar.value = thunderHealth;

        Vector3 target = player.transform.position - gameObject.transform.position;
        Quaternion lookAtPlayer = Quaternion.LookRotation(target);
        healthBar.transform.rotation = lookAtPlayer;
	}

    public void TakeDamage(float damageAmount)
    {
        thunderHealth -= damageAmount;

        //Check for death condition
        StartCoroutine(CheckThunderDead());
    }

    //TODO: enemy death
    IEnumerator CheckThunderDead()
    {
        if (thunderHealth <= 0)
        {
            //Disable the Enemy Ai script
            GetComponent<ThunderEnemyAI>().enabled = false;
            GetComponent<Animator>().enabled = false;

            //Instantiate the lighthning VFX
            GameObject light = (GameObject)Instantiate(ThunderDeadVFXPrefab);
            light.transform.position = thunderDeadVFXSpawnPoint.position;
            Destroy(light, 5f);

            yield return new WaitForSeconds(2.0f);

            //Change the material
            ChangeMaterialOnDead();



            //Instantiate the smoke VFX
            GameObject smoke = (GameObject)Instantiate(ThunderAfterDeadVFXPrefab);
            Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z);
            smoke.transform.position = spawnPosition;
            Destroy(smoke, 5f);

            //Disable the thunder mesh    
            for (int i = 0; i < transform.childCount; ++i)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }

            if (!crystalSpawned)
            {
                //After some time drop the crystal
                GameObject crystal = (GameObject)Instantiate(CrystralPrefab);
                crystal.transform.position = spawnPosition;
                crystalSpawned = true;
            }
        

            yield return new WaitForSeconds(2.0f);

            //Destroy the Enemy
            Destroy(gameObject);
        }
    }

    void ChangeMaterialOnDead()
    {
        //Change the body materials
        bodySkinMesh.materials = bodyDamageMaterials;

        //Change the wings materials
        wingsSkinMesh.materials = wingsDamageMaterials;

        //Change the badge Material
        badgeSkinMesh.material = badgeDamageMaterial;
    }

   
}
