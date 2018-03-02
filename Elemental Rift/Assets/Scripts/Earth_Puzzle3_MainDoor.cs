using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth_Puzzle3_MainDoor : MonoBehaviour {

    public bool isActive = false;
    public bool executeOnce = true;
    float Current_PositionX;
    float Current_PositionY;
    float Current_PositionZ;

    float Destination_X;
    float Destination_Y;
    float Destination_Z;

    private void Start()
    {
        Current_PositionX = transform.position.x;
        Current_PositionY = transform.position.y;
        Current_PositionZ = transform.position.z;


        Destination_Y = 111.0f;

    }
    void Update () {
		
        if(Earth_Puzzle3_StaticVariables.Blue_Exclamation==1 && Earth_Puzzle3_StaticVariables.Red_Exclamation == 1 && Earth_Puzzle3_StaticVariables.Green_Exclamation == 1)
        {
            isActive = true;
        }


        if (isActive && executeOnce)
        {
            //Debug.Log(Destination_X);
            if (Current_PositionY > Destination_Y)
            {
                transform.position += (-Vector3.up) * 1.0f * Time.deltaTime;
            }
            else
            {
                isActive = false;
                executeOnce = false;
            }





            Current_PositionX = transform.position.x;
            Current_PositionY = transform.position.y;
            Current_PositionZ = transform.position.z;
        }





    }
}
