using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tut_reflect : MonoBehaviour {

    public GameObject reflect_tut;

    public GameObject torch;
    public GameObject target;

    Earth_Puzzle1 epzl;
    FlameTorch ftorch;
	// Use this for initialization
	void Start () {
        ftorch = torch.GetComponent<FlameTorch>();
        epzl = target.gameObject.GetComponent<Earth_Puzzle1>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!epzl.isActive)
        {
            if (ftorch.isActive)
            {
                reflect_tut.SetActive(true);
            }
            else
            {
                reflect_tut.SetActive(false);
            }
        }
        else
        {
            reflect_tut.SetActive(false);
        }
    }
}
