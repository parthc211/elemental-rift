using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThunderEnemyHealth : MonoBehaviour {

    // Use this for initialization
    public float thunderHealth = 100f;

    public Slider healthBar;

    private GameObject player;

    public Transform thunderDeadVFXSpawnPoint;
    public GameObject ThunderDeadVFXPrefab;

    public SkinnedMeshRenderer bodySkinMesh;
    public SkinnedMeshRenderer wingsSkinMesh;
    public SkinnedMeshRenderer badgeSkinMesh;
    public Material[] bodyDamageMaterials;
    public Material[] wingsDamageMaterials;
    public Material badgeDamageMaterial;

	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        healthBar.maxValue = thunderHealth;
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
        CheckThunderDead();
    }

    //TODO: enemy death
    void CheckThunderDead()
    {
        if(thunderHealth <= 0)
        {
            //Change the material
            ChangeMaterialOnDead();

            //Instantiate the lighthning VFX
            //GameObject light = (GameObject)Instantiate(ThunderDeadVFXPrefab);
            //light.transform.position = thunderDeadVFXSpawnPoint.position;
            //Destroy(light, 5f);


            //Disable the Thunder Enemy AI amd the thunder mesh renderer script

            //Instantiate the smoke VFX

            //After some time drop the crystal

            //Destroy the Enemy

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
