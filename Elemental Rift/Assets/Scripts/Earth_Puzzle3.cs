using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth_Puzzle3 : MonoBehaviour {

    public bool isActive;

    public float amplitude;          //Set in Inspector 
    public float speed;                  //Set in Inspector 
     float tempVal;
     Vector3 tempPos;
    void Start()
    {
        isActive = false;

        tempVal = transform.position.y;
        tempPos.x= transform.position.x;
        tempPos.z = transform.position.z;
    }
    void Update()
    {
        if (isActive)
        {
            tempPos.y = tempVal + amplitude * Mathf.Sin(speed * Time.time);
            transform.position = tempPos;
            if(gameObject.tag=="Puzzle3_BlueExclamation")
            {
                Earth_Puzzle3_StaticVariables.Blue_Exclamation = 1;
            }
            if (gameObject.tag == "Puzzle3_RedExclamation")
            {
                Earth_Puzzle3_StaticVariables.Red_Exclamation = 1;
            }
            if (gameObject.tag == "Puzzle3_GreenExclamation")
            {
                Earth_Puzzle3_StaticVariables.Green_Exclamation = 1;
            }
        }
        else
        {
            if (gameObject.tag == "Puzzle3_BlueExclamation")
            {
                Earth_Puzzle3_StaticVariables.Blue_Exclamation = 0;
            }
            if (gameObject.tag == "Puzzle3_RedExclamation")
            {
                Earth_Puzzle3_StaticVariables.Red_Exclamation = 0;
            }
            if (gameObject.tag == "Puzzle3_GreenExclamation")
            {
                Earth_Puzzle3_StaticVariables.Green_Exclamation = 0;
            }
        }
    }


    private void OnMouseDown()
    {
        isActive = true;
    }
}
