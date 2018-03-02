using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resource_Manager : MonoBehaviour {

    public float increasePerSecond = 5.0f;
    public float decreasePerSecond = 0.0f;

    public float earthRune = 0.0f;
    public float fireRune = 0.0f;
    public float waterRune = 0.0f;

    public float maxRunes = 100.0f;

    private bool earthflag = true;
    private bool fireflag = false;
    private bool waterflag = false;

    private float startTime;
    private float checkTimer;

    public Image redBarImage;
    public Image blueBarImage;
    public Image greenBarImage;

    public Image redOutImage;
    public Image blueOutImage;
    public Image greenOutImage;

    // Use this for initialization
    void Start()
    {

        startTime = Time.time;

        SetZeroFlag();
        
    }

    // Update is called once per frame
    void Update()
    {
        float redBarRatio = fireRune / maxRunes;
        redBarImage.fillAmount = redBarRatio;

        float blueBarRatio = waterRune / maxRunes;
        blueBarImage.fillAmount = blueBarRatio;

        float greenBarRatio = earthRune / maxRunes;
        greenBarImage.fillAmount = greenBarRatio;

        checkTimer += Time.deltaTime;
        //if (checkTimer > 0.2f)
        //{
        //    checkTimer = 0.0f;
        //    ManageRunes(); 
        //}
        if(Time.timeScale > 0)
        {
            ManageRunes(); 
        }

    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "FireAura")
        {
            SetFireFlag();
        }

        if (other.gameObject.tag == "WaterAura")
        {
            SetWaterFlag();
        }

        if (other.gameObject.tag == "EarthAura")
        {
            SetEarthFlag();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "FireAura")
        {
            SetZeroFlag();
        }

        if (other.gameObject.tag == "WaterAura")
        {
            SetZeroFlag();
        }

        if (other.gameObject.tag == "EarthAura")
        {
            SetZeroFlag();
        }
    }

    void SetEarthFlag()
    {
        earthflag = true;
        fireflag = false;
        waterflag = false;
    }

    void SetFireFlag()
    {
        earthflag = false;
        fireflag = true;
        waterflag = false;
    }

    void SetWaterFlag()
    {
        earthflag = false;
        fireflag = false;
        waterflag = true;
    }

    void SetZeroFlag()
    {
        earthflag = false;
        fireflag = false;
        waterflag = false;
    }

    void ManageRunes()
    {
        if (earthflag == true && fireflag == false && waterflag == false)
        {
            earthRune += increasePerSecond;
           
            fireRune -= decreasePerSecond;
           
            waterRune -= decreasePerSecond;

            greenOutImage.color = Color.white;
            blueOutImage.color = Color.clear;
            redOutImage.color = Color.clear;

            greenBarImage.color = Color.Lerp(Color.white, Color.gray, Mathf.PingPong(Time.time, 1));
            blueBarImage.color = Color.white;
            redBarImage.color = Color.white;

            RuneCheck();

            return;

        }

        if (earthflag == false && fireflag == true && waterflag == false)
        {

            earthRune -= decreasePerSecond;

            fireRune += increasePerSecond;
           
            waterRune -= decreasePerSecond;

            greenOutImage.color = Color.clear;
            blueOutImage.color = Color.clear;
            redOutImage.color = Color.white;

            greenBarImage.color = Color.white;
            blueBarImage.color = Color.white;
            redBarImage.color = Color.Lerp(Color.white, Color.gray, Mathf.PingPong(Time.time, 1));

            RuneCheck();
            return;
        }

        if (earthflag == false && fireflag == false && waterflag == true)
        {

            earthRune -= decreasePerSecond;
           
            fireRune -= decreasePerSecond;
            
            waterRune += increasePerSecond;

            greenOutImage.color = Color.clear;
            blueOutImage.color = Color.white;
            redOutImage.color = Color.clear;

            greenBarImage.color = Color.white;
            blueBarImage.color = Color.Lerp(Color.white, Color.gray, Mathf.PingPong(Time.time, 1));
            redBarImage.color = Color.white;

            RuneCheck();

            return;
        }

        if (earthflag == false && fireflag == false && waterflag == false)
        {
            earthRune -= decreasePerSecond;


            fireRune -= decreasePerSecond;


            waterRune -= decreasePerSecond;

            greenOutImage.color = Color.clear;
            blueOutImage.color = Color.clear;
            redOutImage.color = Color.clear;

            greenBarImage.color = Color.white;
            blueBarImage.color = Color.white;
            redBarImage.color = Color.white;

            RuneCheck();

            return;

        }

    }

    void RuneCheck()
    {
        if (earthRune >= maxRunes)
            earthRune = maxRunes;

        if (fireRune >= maxRunes)
            fireRune = maxRunes;

        if (waterRune >= maxRunes)
            waterRune = maxRunes;

        if (earthRune <= 0)
            earthRune = 0;

        if (fireRune <= 0)
            fireRune = 0;

        if (waterRune <= 0)
            waterRune = 0;
    }

    
}
