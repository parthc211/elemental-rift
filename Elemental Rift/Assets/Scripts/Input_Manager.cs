using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Input_Manager : MonoBehaviour {
   
    public GameObject fireballPrefab;
    public GameObject freezeEffect;
    public GameObject IceShieldPrefab;
    public GameObject knockBackEffect;
    public GameObject weldGO;

    public float fireballCost = 40.0f;
    public float weldCost = 1.0f;
    public float freezeCost = 50.0f;
    public float shieldCost = 2.0f;
    public float eqCost = 30.0f;
    public float telekCost = 0.5f;

    public float spellRange = 20.0f;
    public Camera camera;
    public GameObject target;
    
    public Projector fireballDecal;
    public Projector fireballDecalOff;
    public Projector knockbackDecal;

    public Sprite fireBallSprite;
    public Sprite deactFireBallSprite;
    public Sprite weldSprite;
    public Sprite deactWeldSprite;
    public Sprite freezeSprite;
    public Sprite deactFreezeSprite;
    public Sprite shieldSprite;
    public Sprite deactShieldSprite;
    public Sprite eqSprite;
    public Sprite deactEQSprite;
    public Sprite telekSprite;
    public Sprite deactTelekSprite;

    public Sprite singleTargetReticle;
    public Sprite outOfRangeReticle;
    public Sprite aoeReticle;

    public GameObject blastCollider;
    private GameObject colliderObj;

    private Vector3 rayDir;
    private float rayDist;

    Resource_Manager resource_Manager;

    public Image fireBallImage;
    public Image weldImage;
    public Image freezeImage;
    public Image shieldImage;
    public Image eqImage;
    public Image telekImage;
    public Image spellLogoImage;

    public Image uiBck;
    public Sprite uiBckRed;
    public Sprite uiBckBlue;
    public Sprite uiBckGreen;

    public Image wheelFireballBack;
    public Image wheelWeldBack;
    public Image wheelFreezeBack;
    public Image wheelShieldBack;
    public Image wheelEqBack;
    public Image wheelTelekBack;

    private SpriteRenderer reticleImage;

    private bool sunStrikeFlag = false;
    private bool volcanoFlag = false;
    //private bool freezeFlag = false;
    private bool knockBackFlag = false;

    private bool fireBallFlag = false;
    private bool weldFlag = false;
    private bool freezeFlag = false;
    private bool shieldFlag = false;
    private bool eqFlag = false;
    private bool telekFlag = false;

    public bool canCast = true;

    private bool shieldActivateFlag = false;
    private float shieldTimer;

    private Projector fireProj;
    private Projector fireProjOff;
    private Projector knockbackProj;
    private RaycastHit rayInfo;
    
    private GameObject carriedObject;
    private bool carrying = false;
    public float telekDistance = 10.0f;
    public float telekSmooth = 4.0f;

    private bool weldUse = false;
    private bool shieldUse = false;

    private bool knockBack = false;
    private float knockBackTimer = 5f;
    public float colliderIncrease = 300f;

    private bool usable = false;

    public GameObject fireAuraR;
    public GameObject fireAuraL;
    public GameObject earthAuraR;
    public GameObject earthAuraL;
    public GameObject waterAuraR;
    public GameObject waterAuraL;

    public GameObject weldTool;
    public GameObject fireballTool;
    public GameObject freezeTool;
    public GameObject shieldTool;
    public GameObject telekTool;
    public GameObject eqTool;

    [HideInInspector]
    public Vector3 initialfb;
    [HideInInspector]
    public Vector3 finalfb;
    [HideInInspector]
    public bool telekUse = false;

    // Use this for initialization
    void Start()
    {
        resource_Manager = gameObject.GetComponent<Resource_Manager>();

        reticleImage = target.GetComponent<SpriteRenderer>();

        fireProj = Instantiate(fireballDecal);
        fireProj.gameObject.SetActive(false);

        fireProjOff = Instantiate(fireballDecalOff);
        fireProjOff.gameObject.SetActive(false);

        knockbackProj = Instantiate(knockbackDecal);
        knockbackProj.gameObject.SetActive(false);

        weldGO.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        reticleImage.sprite = aoeReticle;

        rayDir = target.transform.position - camera.transform.position;
        if (fireBallFlag == true)
        {
            if (Physics.Raycast(camera.transform.position, rayDir, out rayInfo, spellRange))
            {
                if (resource_Manager.fireRune >= fireballCost)
                {
                    //fireProj.gameObject.GetComponent<Material>().color = Color.red;
                    fireProj.gameObject.SetActive(true);
                    fireProjOff.gameObject.SetActive(false);
                }
                else
                {
                    //fireProj.gameObject.GetComponent<Shader>(). = Color.grey;
                    fireProj.gameObject.SetActive(false);
                    fireProjOff.gameObject.SetActive(true);
                }
                //fireProj.gameObject.SetActive(true);
                fireProj.gameObject.transform.position = rayInfo.point + Vector3.up * 2.5f;
                fireProj.gameObject.transform.rotation = Quaternion.Euler(90, 0, -gameObject.transform.rotation.eulerAngles.y);
                fireProjOff.gameObject.transform.position = rayInfo.point + Vector3.up * 2.5f;
                fireProjOff.gameObject.transform.rotation = Quaternion.Euler(90, 0, -gameObject.transform.rotation.eulerAngles.y);
                knockbackProj.gameObject.SetActive(false);
                
            }
            else
            {
                //reticleImage.sprite = outOfRangeReticle;
                fireProj.gameObject.SetActive(false);
                fireProjOff.gameObject.SetActive(false);

            }
        }
        else
        {
            fireProj.gameObject.SetActive(false);
        }
        

        


        CheckSpellAvailability();
        CheckSpellLogo();
        
        if (Input.GetMouseButtonDown(0) && canCast == true)
        {
            CastSpell();
        }

        if (telekFlag == true)
        {
            if (Input.GetMouseButtonUp(0) || resource_Manager.earthRune < telekCost)
            {
                telekUse = false;
            }

            if (carrying)
            {
                //Carry(carriedObject);
                earthAuraL.SetActive(true);
                earthAuraR.SetActive(true);
                if (telekUse == false)
                {
                    DropObject();
                    earthAuraL.SetActive(false);
                    earthAuraR.SetActive(false);
                }

                resource_Manager.earthRune -= Time.deltaTime * 1.5f;
            }
            else
            {
                if (telekUse == true)
                {
                    PickUp();
                    resource_Manager.earthRune -= Time.deltaTime * 1.5f;
                    earthAuraL.SetActive(true);
                    earthAuraR.SetActive(true);
                }
            }

            if (telekUse == false)
            {

                earthAuraL.SetActive(false);
                earthAuraR.SetActive(false);
            }
        }
        else
        {
            if (carrying)
            {
                DropObject();

            }
            earthAuraL.SetActive(false);
            earthAuraR.SetActive(false);
        }

        if (shieldFlag == true)
        {
            if (Input.GetMouseButtonUp(0) || resource_Manager.waterRune < shieldCost)
            {
                shieldUse = false;
                waterAuraL.SetActive(false);
                waterAuraR.SetActive(false);
            }

            if(shieldUse == true)
            {
                IceShieldPrefab.SetActive(true);
                resource_Manager.waterRune -= Time.deltaTime * 1.5f;
                waterAuraL.SetActive(true);
                waterAuraR.SetActive(true);

            }
            else
            {
                IceShieldPrefab.SetActive(false);
                waterAuraL.SetActive(false);
                waterAuraR.SetActive(false);

            }
        }
        else
        {
            shieldUse = false;
            IceShieldPrefab.SetActive(false);
            waterAuraL.SetActive(false);
            waterAuraR.SetActive(false);

        }

        if (weldFlag == true)
        {
            if (Input.GetMouseButtonUp(0) || resource_Manager.fireRune < weldCost)
            {
                weldUse = false;
                fireAuraL.SetActive(false);
                fireAuraR.SetActive(false);

            }

            if (weldUse == true)
            {
                weldGO.SetActive(true);
                resource_Manager.fireRune -= Time.deltaTime * 1.5f;
                fireAuraL.SetActive(true);
                fireAuraR.SetActive(true);
            }
            else
            {
                weldGO.SetActive(false);
                fireAuraL.SetActive(false);
                fireAuraR.SetActive(false);
            }
        }
        else
        {
            weldUse = false;
            weldGO.SetActive(false);
            fireAuraL.SetActive(false);
            fireAuraR.SetActive(false);
        }

        if(eqFlag == true)
        {
            if (knockBack == true)
            {
                knockBackTimer -= Time.deltaTime;
                if (knockBackTimer <= 0)
                {
                    knockBack = false;
                    knockBackTimer = 5f;
                }
            }
        }
       
    }

    private void FixedUpdate()
    {
        if (telekFlag == true)
        {

            if (carrying)
            {
                Carry(carriedObject);
                //earthAuraL.SetActive(true);
                //earthAuraR.SetActive(true);
                //if (telekUse == false)
                //{
                //    DropObject();
                //    earthAuraL.SetActive(false);
                //    earthAuraR.SetActive(false);
                //}

                //resource_Manager.earthRune -= Time.deltaTime * 1.5f;
            }
        //    else
        //    {
        //        if (telekUse == true)
        //        {
        //            PickUp();
        //            resource_Manager.earthRune -= Time.deltaTime * 1.5f;
        //            earthAuraL.SetActive(true);
        //            earthAuraR.SetActive(true);
        //        }
        //    }

        //    if (telekUse == false)
        //    {

        //        earthAuraL.SetActive(false);
        //        earthAuraR.SetActive(false);
        //    }
        //}
        //else
        //{
        //    if (carrying)
        //    {
        //        DropObject();

        //    }
        //    earthAuraL.SetActive(false);
        //    earthAuraR.SetActive(false);
        }
    }
    void CastSpell()
    {
        

        if (fireBallFlag == true && resource_Manager.fireRune >=fireballCost)
        {
            
            RaycastHit hit;
            if (Physics.Raycast(camera.transform.position, rayDir, out hit, spellRange))
            {
                resource_Manager.fireRune -= fireballCost;
                //Instantiate(volcano, hit.point + Vector3.up * 2.5f, Quaternion.identity);
                initialfb = new Vector3(camera.transform.position.x, camera.transform.position.y + 7.0f, camera.transform.position.z);
                finalfb = hit.point;
                Instantiate(fireballPrefab, initialfb, Quaternion.identity);
            }
        }

        if (weldFlag == true && resource_Manager.fireRune >= weldCost)
        {
            weldUse = true;
            
        }

        if (freezeFlag == true && resource_Manager.waterRune >= freezeCost)
        {
            resource_Manager.waterRune -= freezeCost;
            Vector3 startPos = camera.transform.position ;
            Vector3 dir = reticleImage.transform.position - (startPos + Vector3.down * 0.01f);
            GameObject projectile = Instantiate(freezeEffect, startPos + Vector3.down * 0.5f, Quaternion.LookRotation(dir));
            Destroy(projectile, 1.0f);

            

        }

        if (shieldFlag == true && resource_Manager.waterRune >= shieldCost)
        {
            shieldUse = true;
            
        }

        if (eqFlag == true && resource_Manager.earthRune >= eqCost)
        {

            resource_Manager.earthRune -= eqCost;
            //GameObject knock = Instantiate(knockBackEffect, hit.point + Vector3.up * 1.0f, transform.rotation);
            //Destroy(knock, 2f);

            //GameObject knock = Instantiate(knockBackEffect);
            //knock.transform.position = transform.position;
            //colliderObj = (GameObject)Instantiate(blastCollider, transform.position, transform.rotation);
            //Destroy(knock, 5f);

            knockBack = true;

            GameObject knock = Instantiate(knockBackEffect);
            SphereCollider knockSphereCollider = knock.GetComponentInChildren<SphereCollider>();

            knock.transform.position = transform.position;

            knockSphereCollider.enabled = true;
            knockSphereCollider.radius += colliderIncrease * Time.deltaTime;
            Destroy(knock, 2f);
        }

        if (telekFlag == true && resource_Manager.earthRune >= telekCost)
        {
            telekUse = true;
        }
    }

    void Carry(GameObject carried)
    {
        Vector3 currentObjPos = carried.transform.position;
        Vector3 telekDist = camera.transform.position + camera.transform.forward * telekDistance;
        //carried.transform.position = Vector3.Lerp(carried.transform.position, camera.transform.position + camera.transform.forward * telekDistance, Time.deltaTime * telekSmooth);
        //carriedObject.transform.rotation = Quaternion.identity;
        Vector3 difference = telekDist - currentObjPos;

        //float thrustfactor = Vector3.Distance(currentObjPos, telekDist);
        float thrustfactor = Vector3.Magnitude(difference);
        if (thrustfactor < 2f )
        {
            carried.GetComponent<Rigidbody>().velocity = Vector3.zero;
            carried.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            carried.GetComponent<Rigidbody>().AddForce(Vector3.zero, ForceMode.Force);
        }
        else
        {
            //carried.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            float thrust = Mathf.Lerp(-1f, 1f, thrustfactor);
            carried.GetComponent<Rigidbody>().AddForce(difference * 120f , ForceMode.Force);
        }
        


    }

    void PickUp()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, rayDir, out hit, spellRange))
        {
            if(hit.collider.gameObject.GetComponent<pickupable>())
            {
                carrying = true;
                carriedObject = hit.collider.gameObject;
                carriedObject.GetComponent<Rigidbody>().useGravity = false;
                
            }
        }
    }

    public void DropObject()
    {
        carrying = false;
        carriedObject.GetComponent<Rigidbody>().useGravity = true;
        carriedObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        carriedObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        carriedObject.GetComponent<Rigidbody>().AddForce(Vector3.zero, ForceMode.Force);
        carriedObject = null;
    }
    void CheckSpellAvailability()
    {
        if(resource_Manager.fireRune >= fireballCost)
        {
            fireBallImage.sprite = fireBallSprite;
            fireBallImage.color = Color.white;
            wheelFireballBack.fillAmount = 1;
        }
        else
        {
            fireBallImage.sprite = deactFireBallSprite;
            fireBallImage.color = Color.gray;
            wheelFireballBack.fillAmount = resource_Manager.fireRune / fireballCost;
        }
        
        if (resource_Manager.fireRune >= weldCost)
        {
            weldImage.sprite = weldSprite;
            weldImage.color = Color.white;
            wheelWeldBack.fillAmount = 1;
        }
        else
        {
            weldImage.sprite = deactWeldSprite;
            weldImage.color = Color.gray;
            wheelWeldBack.fillAmount = resource_Manager.fireRune / weldCost;
        }

        if (resource_Manager.waterRune >= freezeCost)
        {
            freezeImage.sprite = freezeSprite;
            freezeImage.color = Color.white;
            wheelFreezeBack.fillAmount = 1;
        }
        else
        {
            freezeImage.sprite = deactFreezeSprite;
            freezeImage.color = Color.gray;
            wheelFreezeBack.fillAmount = resource_Manager.waterRune / freezeCost;
        }

        if (resource_Manager.waterRune >= shieldCost)
        {
            shieldImage.sprite = shieldSprite;
            shieldImage.color = Color.white;
            wheelShieldBack.fillAmount = 1;
        }
        else
        {
            shieldImage.sprite = deactShieldSprite;
            shieldImage.color = Color.gray;
            wheelShieldBack.fillAmount = resource_Manager.waterRune / shieldCost;
        }

        if (resource_Manager.earthRune >= eqCost)
        {
            eqImage.sprite = eqSprite;
            eqImage.color = Color.white;
            wheelEqBack.fillAmount = 1;
        }
        else
        {
            eqImage.sprite = deactEQSprite;
            eqImage.color = Color.gray;
            wheelEqBack.fillAmount = resource_Manager.earthRune / eqCost;
        }

        if (resource_Manager.earthRune >= telekCost)
        {
            telekImage.sprite = telekSprite;
            telekImage.color = Color.white;
            wheelTelekBack.fillAmount = 1;
        }
        else
        {
            telekImage.sprite = deactTelekSprite;
            telekImage.color = Color.gray;
            wheelTelekBack.fillAmount = resource_Manager.earthRune / telekCost;
        }
    }

    void CheckSpellLogo()
    {
        if (resource_Manager.fireRune >= fireballCost && fireBallFlag == true)
        {
            spellLogoImage.sprite = fireBallSprite;
            spellLogoImage.color = Color.Lerp(Color.white, Color.gray, Mathf.PingPong(Time.time, 1));
            uiBck.sprite = uiBckRed;
            uiBck.fillAmount = 1;

            weldTool.SetActive(false);
            fireballTool.SetActive(true);
            freezeTool.SetActive(false);
            shieldTool.SetActive(false);
            telekTool.SetActive(false);
            eqTool.SetActive(false);

            
        }
        else if (fireBallFlag == true)
        {
            spellLogoImage.sprite = deactFireBallSprite;
            spellLogoImage.color = Color.gray;
            uiBck.sprite = uiBckRed;
            uiBck.fillAmount = resource_Manager.fireRune / fireballCost;

            weldTool.SetActive(false);
            fireballTool.SetActive(true);
            freezeTool.SetActive(false);
            shieldTool.SetActive(false);
            telekTool.SetActive(false);
            eqTool.SetActive(false);
        }

        if (resource_Manager.fireRune >= weldCost && weldFlag == true)
        {
            spellLogoImage.sprite = weldSprite;
            spellLogoImage.color = Color.Lerp(Color.white, Color.gray, Mathf.PingPong(Time.time, 1));
            uiBck.sprite = uiBckRed;
            uiBck.fillAmount = 1;

            weldTool.SetActive(true);
            fireballTool.SetActive(false);
            freezeTool.SetActive(false);
            shieldTool.SetActive(false);
            telekTool.SetActive(false);
            eqTool.SetActive(false);
        }
        else if (weldFlag == true)
        {
            spellLogoImage.sprite = deactWeldSprite;
            spellLogoImage.color = Color.gray;
            uiBck.sprite = uiBckRed;
            uiBck.fillAmount = resource_Manager.fireRune / weldCost;

            weldTool.SetActive(true);
            fireballTool.SetActive(false);
            freezeTool.SetActive(false);
            shieldTool.SetActive(false);
            telekTool.SetActive(false);
            eqTool.SetActive(false);
        }

        if (resource_Manager.waterRune >= freezeCost && freezeFlag == true)
        {
            spellLogoImage.sprite = freezeSprite;
            spellLogoImage.color = Color.Lerp(Color.white, Color.gray, Mathf.PingPong(Time.time, 1));
            uiBck.sprite = uiBckBlue;
            uiBck.fillAmount = 1;

            weldTool.SetActive(false);
            fireballTool.SetActive(false);
            freezeTool.SetActive(true);
            shieldTool.SetActive(false);
            telekTool.SetActive(false);
            eqTool.SetActive(false);
        }
        else if (freezeFlag == true)
        {
            spellLogoImage.sprite = deactFreezeSprite;
            spellLogoImage.color = Color.gray;
            uiBck.sprite = uiBckBlue;
            uiBck.fillAmount = resource_Manager.waterRune / freezeCost;

            weldTool.SetActive(false);
            fireballTool.SetActive(false);
            freezeTool.SetActive(true);
            shieldTool.SetActive(false);
            telekTool.SetActive(false);
            eqTool.SetActive(false);
        }
        if (resource_Manager.waterRune >= shieldCost && shieldFlag == true)
        {
            spellLogoImage.sprite = shieldSprite;
            spellLogoImage.color = Color.Lerp(Color.white, Color.gray, Mathf.PingPong(Time.time, 1));
            uiBck.sprite = uiBckBlue;
            uiBck.fillAmount = 1;

            weldTool.SetActive(false);
            fireballTool.SetActive(false);
            freezeTool.SetActive(false);
            shieldTool.SetActive(true);
            telekTool.SetActive(false);
            eqTool.SetActive(false);
        }
        else if (shieldFlag == true)
        {
            spellLogoImage.sprite = deactShieldSprite;
            spellLogoImage.color = Color.gray;
            uiBck.sprite = uiBckBlue;
            uiBck.fillAmount = resource_Manager.waterRune / shieldCost;

            weldTool.SetActive(false);
            fireballTool.SetActive(false);
            freezeTool.SetActive(false);
            shieldTool.SetActive(true);
            telekTool.SetActive(false);
            eqTool.SetActive(false);
        }

        if (resource_Manager.earthRune >= eqCost && eqFlag == true)
        {
            spellLogoImage.sprite = eqSprite;
            spellLogoImage.color = Color.Lerp(Color.white, Color.gray, Mathf.PingPong(Time.time, 1));
            uiBck.sprite = uiBckGreen;
            uiBck.fillAmount = 1;

            weldTool.SetActive(false);
            fireballTool.SetActive(false);
            freezeTool.SetActive(false);
            shieldTool.SetActive(false);
            telekTool.SetActive(false);
            eqTool.SetActive(true);
        }
        else if (eqFlag == true)
        {
            spellLogoImage.sprite = deactEQSprite;
            spellLogoImage.color = Color.gray;
            uiBck.sprite = uiBckGreen;
            uiBck.fillAmount = resource_Manager.earthRune / eqCost;

            weldTool.SetActive(false);
            fireballTool.SetActive(false);
            freezeTool.SetActive(false);
            shieldTool.SetActive(false);
            telekTool.SetActive(false);
            eqTool.SetActive(true);
        }
        if (resource_Manager.earthRune >= telekCost && telekFlag == true)
        {
            spellLogoImage.sprite = telekSprite;
            spellLogoImage.color = Color.Lerp(Color.white, Color.gray, Mathf.PingPong(Time.time, 1));
            uiBck.sprite = uiBckGreen;
            uiBck.fillAmount = 1;

            weldTool.SetActive(false);
            fireballTool.SetActive(false);
            freezeTool.SetActive(false);
            shieldTool.SetActive(false);
            telekTool.SetActive(true);
            eqTool.SetActive(false);
        }
        else if (telekFlag == true)
        {
            spellLogoImage.sprite = deactTelekSprite;
            spellLogoImage.color = Color.gray;
            uiBck.sprite = uiBckGreen;
            uiBck.fillAmount = resource_Manager.earthRune / telekCost;

            weldTool.SetActive(false);
            fireballTool.SetActive(false);
            freezeTool.SetActive(false);
            shieldTool.SetActive(false);
            telekTool.SetActive(true);
            eqTool.SetActive(false);
        }
    }

    

    public void clickOnFireBall()
    {
        fireBallFlag = true;
        weldFlag = false;
        freezeFlag = false;
        shieldFlag = false;
        eqFlag = false;
        telekFlag = false;
    }

    public void clickOnWeld()
    {
        fireBallFlag = false;
        weldFlag = true;
        freezeFlag = false;
        shieldFlag = false;
        eqFlag = false;
        telekFlag = false;
    }

    public void clickOnFreeze()
    {
        fireBallFlag = false;
        weldFlag = false;
        freezeFlag = true;
        shieldFlag = false;
        eqFlag = false;
        telekFlag = false;
    }

    public void clickOnShield()
    {
        fireBallFlag = false;
        weldFlag = false;
        freezeFlag = false;
        shieldFlag = true;
        eqFlag = false;
        telekFlag = false;
    }

    public void clickOnEQ()
    {
        fireBallFlag = false;
        weldFlag = false;
        freezeFlag = false;
        shieldFlag = false;
        eqFlag = true;
        telekFlag = false;
    }

    public void clickOnTelek()
    {
        fireBallFlag = false;
        weldFlag = false;
        freezeFlag = false;
        shieldFlag = false;
        eqFlag = false;
        telekFlag = true;
    }


}
