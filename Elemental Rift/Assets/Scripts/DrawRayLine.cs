using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawRayLine : MonoBehaviour
{
    public string LaserTag;

    public string EnterTag;
    public string ExitTag;

    public float laserDamage = 10.0f;

    public GameObject target;
    private GameObject hitObject;
    bool hitting = false;
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

                if (reflectInfo.transform.tag == LaserTag)
                {
                    GameObject go = reflectInfo.transform.gameObject;

                    if(hitObject == null)
                    {
                        go.SendMessage(EnterTag);
                    }
                    else if(hitObject.GetInstanceID() == go.GetInstanceID())
                    {
                        //hitObject.SendMessage("OnRayStay");
                    }
                    else
                    {
                        hitObject.SendMessage(ExitTag);
                        go.SendMessage(EnterTag);
                    }

                    hitting = true;
                    hitObject = go;
                    //lineRender.SetPosition(0, rayOG.origin);
                    //lineRender.SetPosition(1, rayInfo.point);
                    //lineRender.SetPosition(2, reflectInfo.point);
                }
                else if (reflectInfo.transform.tag == "ThunderEnemy")
                {
                    reflectInfo.collider.GetComponent<ThunderEnemyHealth>().TakeDamage(laserDamage * Time.deltaTime);
                }

                else if (hitting)
                {
                    //hitObject.SendMessage(ExitTag);
                    hitting = false;
                    hitObject = null;
                }

            }
            else
            {
                
                lineRender.SetPosition(0, rayOG.origin);
                lineRender.SetPosition(1, rayInfo.point);
                lineRender.SetPosition(2, rayRef.GetPoint(50));
                if(hitting)
                {
                    hitObject.SendMessage(ExitTag);
                    hitting = false;
                    hitObject = null; 
                }
                
                
            }
        }
        else
        {
            lineRender.SetPosition(0, rayOG.origin);
            lineRender.SetPosition(1, rayInfo.point);
            lineRender.SetPosition(2, rayInfo.point);
            //if (hitting)
            //{
            //    hitObject.SendMessage(ExitTag);
            //    hitting = false;
            //    hitObject = null;
            //}
        }

        //if(rayInfo.collider.tag == "ThunderEnemy")
        //{
        //    Debug.Log("Hit thunder enemy");
        //    //rayInfo.collider.GetComponent<ThunderEnemyHealth>().TakeDamage(laserDamage * Time.deltaTime);
        //}
        
        //Debug.DrawRay(transform.position, rayOG.GetPoint(5) - transform.position, Color.red);
        //Debug.DrawRay(rayInfo.point, reflectVec, Color.blue);
    }
}
