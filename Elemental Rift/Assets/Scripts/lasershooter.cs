using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lasershooter : MonoBehaviour {

    float time;
    public GameObject laserball;
    public GameObject aim;
    Vector3 dir;

    // Use this for initialization
    void Start()
    {
        time = 0.0f;
        dir = gameObject.transform.position - aim.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 0.20f)
        {
            time = 0.0f;
            GameObject laserballProj = (GameObject)Instantiate(laserball);
            laserballProj.transform.position = gameObject.transform.position;
            laserballProj.GetComponent<laserball>().SetDirection(dir);
        }
    }
}
