using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth_Puzzle1 : MonoBehaviour {


    public bool isActive=false;
    float Current_PositionX;
    float Current_PositionY;
    float Current_PositionZ;

    float Destination_X;
    float Destination_Y;
    float Destination_Z;

    void Start () {

        Current_PositionX = transform.position.x;
        Current_PositionY = transform.position.y;
        Current_PositionZ = transform.position.z;


        Destination_Z = 295.0f;

    }
	
	
	void Update () {
		
        if(isActive)
        {
            //Debug.Log(Destination_Z);
            if (Current_PositionZ < Destination_Z)
            {
                transform.position += Vector3.forward * 5.0f * Time.deltaTime;
            }
            else
            {
                isActive = false;
            }





            Current_PositionX = transform.position.x;
            Current_PositionY = transform.position.y;
            Current_PositionZ = transform.position.z;
        }

    }

    private void OnMouseDown()
    {
        isActive = true;
    }
}
