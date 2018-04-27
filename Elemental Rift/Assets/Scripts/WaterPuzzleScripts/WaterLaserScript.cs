using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterLaserScript : MonoBehaviour {



    public GameObject RubbleObject;

    //public bool isStoneRubbled = false;

    public GameObject WaterFallMiniOne;

    public GameObject WaterFallMiniTwo;

    public GameObject WaterFallOne;

    public GameObject WaterFallTwo;

    public GameObject WaterBase;

    public GameObject laser;

    public GameObject glowingLock;

    public GameObject pyramidDoor;

    public GameObject ThePillar;

    public GameObject TheWater;

    public GameObject leftPane;
    public GameObject rightPane;
    public GameObject lightGlow;

    private bool Flag_ExecutedOnce = false;
    private bool Flag_ExecuteAfterSomeSeconds = false;

    float timer = 0.0f;
    float tempTimer = 0f;

    
    void Start () {

        
        laser.SetActive(false);
        leftPane.SetActive(false);
        rightPane.SetActive(false);
        lightGlow.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

       // isStoneRubbled = StaticVariablesWaterPuzzle.stoneRubbled;
        //Debug.Log("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" + isStoneRubbled);

        if (!RubbleObject && !Flag_ExecutedOnce)
        {
            WaterFallMiniOne.SetActive(false);
            WaterFallMiniTwo.SetActive(false);
            WaterFallOne.SetActive(true);
            WaterFallTwo.SetActive(true);
            WaterBase.GetComponent<QuickDoor>().openDoor = true;
            ThePillar.GetComponent<QuickDoor>().openDoor = true;
            TheWater.GetComponent<QuickDoor>().openDoor = true;
            WaterBase.GetComponent<QuickDoor>().openDoor = true;
            Flag_ExecutedOnce = true;
            Flag_ExecuteAfterSomeSeconds = true;
            tempTimer = timer;
            
        }




            if (Flag_ExecuteAfterSomeSeconds && (timer-tempTimer>15))
        {
            UnlockThePyramidDoor();
            Flag_ExecuteAfterSomeSeconds = false;
        }

		
	}


    void UnlockThePyramidDoor()
    {
        laser.SetActive(true);
        leftPane.SetActive(true);
        rightPane.SetActive(true);
        lightGlow.SetActive(true);
        pyramidDoor.GetComponent<QuickDoor>().openDoor = true;

    }
}