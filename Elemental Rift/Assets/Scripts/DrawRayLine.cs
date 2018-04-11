using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawRayLine : MonoBehaviour
{

    public GameObject target;

    Vector3 dir;

    RaycastHit rayInfo;
    RaycastHit reflectInfo;

    Ray rayOG;
    Ray rayRef;

    Vector3 incomingVec;
    Vector3 reflectVec;

    LineRenderer lineRender;
    Material mat;
    // Use this for initialization
    void Start()
    {
        lineRender = GetComponent<LineRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        dir = target.transform.position - transform.position;
        rayOG = new Ray(transform.position, dir);
        Physics.Raycast(rayOG, out rayInfo);
        lineRender.material.mainTextureOffset = new Vector2(0, Time.time * 3);
        if(rayInfo.collider.tag == "IceShield")
        {
            incomingVec = rayInfo.point - transform.position;
            reflectVec = Vector3.Reflect(incomingVec, rayInfo.normal);
            //reflectVec *= 5;
            rayRef = new Ray(rayInfo.point, reflectVec);
            if(Physics.Raycast(rayRef, out reflectInfo))
            {
                //Debug.DrawRay(rayInfo.point, reflectVec, Color.blue);
                lineRender.SetPosition(0, rayOG.origin);
                lineRender.SetPosition(1, rayInfo.point);
                lineRender.SetPosition(2, reflectInfo.point);

                if(reflectInfo.collider.tag == "LaserTarget" && reflectInfo.collider.gameObject.GetComponent<LaserTarget>().isActive == false)
                {
                    reflectInfo.collider.gameObject.GetComponent<LaserTarget>().isActive = true;
                }

            }
            else
            {
                lineRender.SetPosition(0, rayOG.origin);
                lineRender.SetPosition(1, rayInfo.point);
                lineRender.SetPosition(2, rayRef.GetPoint(50));
            }
        }
        else
        {
            lineRender.SetPosition(0, rayOG.origin);
            lineRender.SetPosition(1, rayInfo.point);
            lineRender.SetPosition(2, rayInfo.point);
        }

        
        //Debug.DrawRay(transform.position, rayOG.GetPoint(5) - transform.position, Color.red);
        //Debug.DrawRay(rayInfo.point, reflectVec, Color.blue);
    }
}
