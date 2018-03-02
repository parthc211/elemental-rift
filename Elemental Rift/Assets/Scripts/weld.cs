using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weld : MonoBehaviour {

    float timer;
    bool startweld = false;
    bool welding = false;
    GameObject temp;
    public GameObject[] weldhit;
	// Use this for initialization
	void Start () {
        foreach(GameObject wh in weldhit)
        {
            wh.SetActive(false);
        }
        
	}
	
	// Update is called once per frame
	void Update () {
        
        if (startweld == true)
        {
            timer += Time.deltaTime;
            foreach (GameObject wh in weldhit)
            {
                wh.SetActive(true);
            }
            if (timer >= 2.0f)
            {
                weldObj wo = temp.gameObject.GetComponentInParent<weldObj>();
                wo.switchGO();
                foreach (GameObject wh in weldhit)
                {
                    wh.SetActive(false);
                }
                startweld = false;
                temp = null;
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Unwelded")
        {
            timer = 0.0f;
            startweld = true;
            temp = other.transform.gameObject;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            //other.GetComponent<EnemyLogic>().ApplyDamage(1);
        }

        if (other.tag == "RockEnemy")
        {
            other.GetComponent<EnemyHealth>().TakeDamage(Time.deltaTime * 2f);
            foreach (GameObject wh in weldhit)
            {
                wh.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Unwelded")
        {
            startweld = false;
            temp = null;
        }

        if (other.tag == "RockEnemy")
        {
            
            foreach (GameObject wh in weldhit)
            {
                wh.SetActive(false);
            }
        }


    }


}
