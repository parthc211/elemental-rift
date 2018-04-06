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
    public float airRune = 0.0f;

    public float maxRunes = 100.0f;

    private bool earthflag = false;
    private bool fireflag = false;
    private bool waterflag = false;
    private bool airflag = false;

    private float startTime;
    private float checkTimer;

    public Image fireBarImage;
    public Image waterBarImage;
    public Image earthBarImage;
    public Image airBarImage;

    public Image fireOutImage;
    public Image waterOutImage;
    public Image earthOutImage;
    public Image airOutImage;

    // Use this for initialization
    void Start()
    {

        startTime = Time.time;

        SetZeroFlag();
        
    }

    // Update is called once per frame
    void Update()
    {
        float fireBarRatio = fireRune / maxRunes;
        fireBarImage.fillAmount = fireBarRatio;

        float waterBarRatio = waterRune / maxRunes;
        waterBarImage.fillAmount = waterBarRatio;

        float earthBarRatio = earthRune / maxRunes;
        earthBarImage.fillAmount = earthBarRatio;

        float airBarRatio = airRune / maxRunes;
        airBarImage.fillAmount = airBarRatio;

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

        if (other.gameObject.tag == "AirAura")
        {
            SetAirFlag();
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

        if (other.gameObject.tag == "AirAura")
        {
            SetZeroFlag();
        }
    }

    void SetEarthFlag()
    {
        earthflag = true;
        fireflag = false;
        waterflag = false;
        airflag = false;
    }

    void SetFireFlag()
    {
        earthflag = false;
        fireflag = true;
        waterflag = false;
        airflag = false;
    }

    void SetWaterFlag()
    {
        earthflag = false;
        fireflag = false;
        waterflag = true;
        airflag = false;
    }

    void SetAirFlag()
    {
        earthflag = false;
        fireflag = false;
        waterflag = false;
        airflag = true;
    }

    public void SetZeroFlag()
    {
        earthflag = false;
        fireflag = false;
        waterflag = false;
        airflag = false;
    }

    void ManageRunes()
    {
        if (earthflag == true && fireflag == false && waterflag == false && airflag == false)
        {
            earthRune += increasePerSecond;
           
            fireRune -= decreasePerSecond;
           
            waterRune -= decreasePerSecond;

            airRune -= decreasePerSecond;

            earthOutImage.color = Color.white;
            waterOutImage.color = Color.clear;
            fireOutImage.color = Color.clear;
            airOutImage.color = Color.clear;

            earthBarImage.color = Color.Lerp(Color.white, Color.gray, Mathf.PingPong(Time.time, 1));
            waterBarImage.color = Color.white;
            fireBarImage.color = Color.white;
            airBarImage.color = Color.white;

            RuneCheck();

            return;

        }

        if (earthflag == false && fireflag == true && waterflag == false && airflag == false)
        {

            earthRune -= decreasePerSecond;

            fireRune += increasePerSecond;
           
            waterRune -= decreasePerSecond;

            airRune -= decreasePerSecond;

            earthOutImage.color = Color.clear;
            waterOutImage.color = Color.clear;
            fireOutImage.color = Color.white;
            airOutImage.color = Color.clear;

            earthBarImage.color = Color.white;
            waterBarImage.color = Color.white;
            fireBarImage.color = Color.Lerp(Color.white, Color.gray, Mathf.PingPong(Time.time, 1));
            airBarImage.color = Color.white;

            RuneCheck();
            return;
        }

        if (earthflag == false && fireflag == false && waterflag == true && airflag == false)
        {

            earthRune -= decreasePerSecond;
           
            fireRune -= decreasePerSecond;
            
            waterRune += increasePerSecond;

            airRune -= decreasePerSecond;

            earthOutImage.color = Color.clear;
            waterOutImage.color = Color.white;
            fireOutImage.color = Color.clear;
            airOutImage.color = Color.clear;

            earthBarImage.color = Color.white;
            waterBarImage.color = Color.Lerp(Color.white, Color.gray, Mathf.PingPong(Time.time, 1));
            fireBarImage.color = Color.white;
            airBarImage.color = Color.white;

            RuneCheck();

            return;
        }

        if (earthflag == false && fireflag == false && waterflag == false && airflag == true)
        {
            earthRune -= decreasePerSecond;

            fireRune -= decreasePerSecond;

            waterRune -= decreasePerSecond;

            airRune += increasePerSecond;

            earthOutImage.color = Color.clear;
            waterOutImage.color = Color.clear;
            fireOutImage.color = Color.clear;
            airOutImage.color = Color.white;

            earthBarImage.color = Color.white;
            waterBarImage.color = Color.white;
            fireBarImage.color = Color.white;
            airBarImage.color = Color.Lerp(Color.white, Color.gray, Mathf.PingPong(Time.time, 1));

            RuneCheck();

            return;

        }

        if (earthflag == false && fireflag == false && waterflag == false && airflag == false)
        {
            earthRune -= decreasePerSecond;

            fireRune -= decreasePerSecond;

            waterRune -= decreasePerSecond;

            airRune -= decreasePerSecond;

            earthOutImage.color = Color.clear;
            waterOutImage.color = Color.clear;
            fireOutImage.color = Color.clear;
            airOutImage.color = Color.clear;

            earthBarImage.color = Color.white;
            waterBarImage.color = Color.white;
            fireBarImage.color = Color.white;
            airBarImage.color = Color.white;

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

        if (airRune >= maxRunes)
            airRune = maxRunes;

        if (earthRune <= 0)
            earthRune = 0;

        if (fireRune <= 0)
            fireRune = 0;

        if (waterRune <= 0)
            waterRune = 0;

        if (airRune <= 0)
            airRune = 0;
    }

    
}
