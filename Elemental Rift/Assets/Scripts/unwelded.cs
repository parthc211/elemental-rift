using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class unwelded : MonoBehaviour
{

    float timer;
    bool startweld = false;
    bool welding = false;
    public Image overlay;
    
    // Use this for initialization
    void Start()
    {
        

    }
    
    // Update is called once per frame
    void Update()
    {
        overlay.fillAmount = timer / 2.0f;
        if(startweld == false)
        {
            timer = 0.0f;
        }
    }

    private void FixedUpdate()
    {
        startweld = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "weld")
        {
            //Debug.Log(timer);
           // timer = 0.0f;
            //startweld = true;
            //temp = other.transform.gameObject;
        }
    }
    private void OnTriggerStay(Collider other)
    {


        if (other.tag == "weld")
        {
            startweld = true;
            //Debug.Log("Hit");
            timer += Time.deltaTime;
            //startweld = true;
            //temp = other.transform.gameObject;

            if (timer >= 2.0f)
            {
                weldObj wo = gameObject.GetComponentInParent<weldObj>();
                wo.switchGO();

                //startweld = false;
                //temp = null;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "weld")
        {
            Debug.Log("UnHit");
            //startweld = false;
           // temp = null;
            timer = 0f;
        }

        


    }


}
