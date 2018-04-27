using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossScript : MonoBehaviour {


    public GameObject key_torchOne;
    public GameObject key_torchTwo;

    public GameObject ThunderEnemyEntryModel;
    public GameObject ThunderEnemyMainModel;
   

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (ThunderEnemyEntryModel.activeInHierarchy == true)
        {


            if (key_torchOne.GetComponent<FlameTorch>().isActive &&
               key_torchTwo.GetComponent<FlameTorch>().isActive)
            {
                //Debug.Log("Boss Activated!");
                ThunderEnemyEntryModel.SetActive(false);
                ThunderEnemyMainModel.SetActive(true);

            }
        }

	}
}
