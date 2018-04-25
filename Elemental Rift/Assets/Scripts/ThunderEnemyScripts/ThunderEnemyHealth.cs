using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderEnemyHealth : MonoBehaviour {

    // Use this for initialization
    public float thunderHealth = 100f;

    private float resetDamageTimer = 0.0f;

    public float damageTimer = 5.0f;

    public SkinnedMeshRenderer thunderSkinMesh;
    private Material[] ThunderEnemyNormalMaterial;
    public Material[] ThunderEnemyDamageMaterial;

	void Start ()
    {
        //thunderSkinMesh = GetComponentInChildren<SkinnedMeshRenderer>();
        ThunderEnemyNormalMaterial = thunderSkinMesh.materials;
	}
	
	// Update is called once per frame
	void Update ()
    {
        resetDamageTimer -= Time.deltaTime;
		if(resetDamageTimer <= 0.0f)
        {
            thunderSkinMesh.materials = ThunderEnemyNormalMaterial;
        }
	}

    public void TakeDamage(float damageAmount)
    {
        resetDamageTimer = damageTimer;
        thunderHealth -= damageAmount;
        ChangeMaterialOnDamage();
    }

    private void ChangeMaterialOnDamage()
    {
        Debug.Log(thunderSkinMesh);
        thunderSkinMesh.materials = ThunderEnemyDamageMaterial;
    }
}
