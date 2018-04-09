using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawRayLine : MonoBehaviour
{

    public GameObject target;

    Vector3 dir;
    RaycastHit rayInfo;
    RaycastHit reflectInfo;

    Vector3 incomingVec;
    Vector3 reflectVec;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        dir = target.transform.position - transform.position;
        Physics.Raycast(transform.position, dir, out rayInfo);
        
        incomingVec = rayInfo.point - transform.position;
        reflectVec = Vector3.Reflect(incomingVec, rayInfo.normal);
        reflectVec *= 5;
        Physics.Raycast(rayInfo.point, reflectVec, out reflectInfo);
        
        
        Debug.DrawRay(transform.position, rayInfo.point - transform.position, Color.red);
        Debug.DrawRay(rayInfo.point, reflectInfo.point - rayInfo.point, Color.blue);
    }
}
