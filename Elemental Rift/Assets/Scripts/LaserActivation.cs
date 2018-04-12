using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserActivation : MonoBehaviour {

    public GameObject torch;
    public GameObject laser;

    FlameTorch flameTorch;

    void Start()
    {
        flameTorch = torch.GetComponent<FlameTorch>();
    }


    void Update()
    {
        if (flameTorch.isActive == true)
        {
            laser.SetActive(true);
        }
        else
        {
            laser.SetActive(false);
        }

    }
}
