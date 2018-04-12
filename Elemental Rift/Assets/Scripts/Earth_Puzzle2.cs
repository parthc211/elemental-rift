using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth_Puzzle2 : MonoBehaviour
{

    public GameObject leftPane;
    public GameObject rightPane;
    public GameObject lightGlow;
    public GameObject mover;

    bool left = false;
    bool right = false;

    bool isActive = false;
    void Start()
    {

    }


    void Update()
    {
        if(left && right)
        {
            isActive = true;
        }

        if (isActive)
        {
            
            lightGlow.SetActive(true);
            mover.GetComponent<QuickMover>().isMoving = true;
            leftPane.SetActive(true);
            rightPane.SetActive(true);
        }

    }

    public void OnRayEnter1()
    {
        leftPane.SetActive(true);
        left = true;
    }
    public void OnRayExit1()
    {
        leftPane.SetActive(false);
        left = false;
    }

    public void OnRayEnter2()
    {
        rightPane.SetActive(true);
        right = true;
    }
    public void OnRayExit2()
    {
        rightPane.SetActive(false);
        right = false;
    }
}
