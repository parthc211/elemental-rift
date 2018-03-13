using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_health : MonoBehaviour {

    public GameObject healthBar;

    public float health = 100.0f;

    private Image healthBarImage;
    private bool imStopDmg = false;
    float dmgTimer = 0.0f;

    public Image splatterImage;
    public Color splatterColor;
    public float splatterSpeed = 2.0f;

    public Image fadeHealth;
    private CamShake camShake;
    private bool damaged;

    //private Transform lastCheckpoint;
    private Vector3 lastCheckPointPos;
    private Quaternion lastCheckPointRot;
    private Resource_Manager resource_manager;
  
    
	// Use this for initialization
	void Start () {
        healthBarImage = healthBar.GetComponent<Image>();
        damaged = false;

        camShake = Camera.main.gameObject.GetComponent<CamShake>();
        resource_manager = gameObject.GetComponent<Resource_Manager>();
        lastCheckPointPos = transform.position;
        lastCheckPointRot = transform.rotation;
        //lastCheckpoint = gameObject.transform;
        //Debug.Log(lastCheckpoint.position);
       // Debug.Log(lastCheckpoint.rotation);
    }
	
	// Update is called once per frame
	void Update () {
        float healthRatio = health / 100.0f;
        healthBarImage.fillAmount = healthRatio;

        

        DamageSplatter();
        
        HealPlayer();
        if (Input.GetKeyDown(KeyCode.O))
        {
            health -= 10.0f;
            damaged = true;
        }

        if (health > 40)
        {
            fadeHealth.color = Color.clear;
        }
        else
        {
            fadeHealth.color = new Color(1, 1, 1, 1.0f - healthRatio);
        }

        //dmgTimer += Time.deltaTime;

        //if (dmgTimer < 4)
        //    imStopDmg = true;
        //else
        //    imStopDmg = false;

        CheckDead();
    }

    private void HealPlayer()
    {
        if(health >= 100.0f)
        {
            health = 100.0f;
        }
        else
        {
            health += Time.deltaTime * 1.0f;
        }
    }
    private void DamageSplatter()
    {
        if(damaged == true)
        {
            splatterImage.color = splatterColor;
            healthBarImage.color = Color.red;
            camShake.shakeNow = true;
        }
        else
        {
            splatterImage.color = Color.Lerp(splatterImage.color, Color.clear, splatterSpeed * Time.deltaTime);
            healthBarImage.color = Color.Lerp(healthBarImage.color, Color.white, 2.0f * Time.deltaTime);
        }
        
        damaged = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        //if(collision.gameObject.tag == "Enemy")
        //{
        //    Destroy(collision.gameObject);
        //    health -= 10.0f;
        //}

        //if (collision.gameObject.tag == "ImmortalEnemy")
        //{
        //    if(imStopDmg == false)
        //    {
        //        health -= 15.0f;
        //        dmgTimer = 0.0f;
        //    }
            
        //}

        if (collision.gameObject.tag == "Death")
        {
            damaged = true;
            health -= 101.0f;
        }
    }

    

    void CheckDead()
    {
        if (health <= 0)
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            gameObject.transform.position = lastCheckPointPos;
            gameObject.transform.rotation = lastCheckPointRot;
           // Debug.Log(lastCheckpoint.position);
           // Debug.Log(lastCheckpoint.rotation);
            resource_manager.SetZeroFlag();
            resource_manager.fireRune = 0;
            resource_manager.waterRune = 0;
            resource_manager.earthRune = 0;
            health = 100.0f;
        }
    }

    public void bulletdmg()
    {
        health -= 25.0f;
        damaged = true;
    }

    public void takedmg(float dmg)
    {
        health -= dmg;
        damaged = true;
    }

    public void laserdmg()
    {
        health -= 4.0f;
        damaged = true;
    }

    public void SetCheckpoint(Vector3 pos, Quaternion rot)
    {
        lastCheckPointPos = pos;
        lastCheckPointRot = rot;
        //Debug.Log(lastCheckpoint.position);
       // Debug.Log(lastCheckpoint.rotation);
    }
}
