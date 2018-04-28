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
    public Sprite uiBckFire;
    public Sprite uiBckWater;
    public Sprite uiBckEarth;
    public Sprite uiBckAir;

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

    public Material[] fireHandR;
    public Material[] fireHandL;
    public Material[] earthHandR;
    public Material[] earthHandL;
    public Material[] waterHandR;
    public Material[] waterHandL;
    public Material[] airHandR;
    public Material[] airHandL;

    public GameObject HandLeft;
    public GameObject HandRight;



    public GameObject weldTool;
    public GameObject fireballTool;
    public GameObject freezeTool;
    public GameObject shieldTool;
    public GameObject telekTool;
    public GameObject eqTool;

    public GameObject hands;
    private Animator handAnim;
    bool weldAnim = false;
    bool shieldAnim = false;
    bool telekAnim = false;

    
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
        handAnim = hands.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        reticleImage.sprite = aoeReticle;
        //if(carriedObject == null)
        //{
        //    telekUse = false;

        //}

        rayDir = target.transform.position - camera.transform.position;
        if (fireBallFlag == true)
        {
            if (Physics.Raycast(camera.transform.position, rayDir, out rayInfo, spellRange))
            {
                if (resource_Manager.fireRune >= fireballCost)
                {
                    //fireProj.gameObject.GetComponent<Material>().color = Color.Fire;
                    fireProj.gameObject.SetActive(true);
                    fireProjOff.gameObject.SetActive(false);
                    fireProj.gameObject.transform.position = rayInfo.point + Vector3.up * 2.5f;
                    fireProj.gameObject.transform.rotation = Quaternion.Euler(90, 0, -gameObject.transform.rotation.eulerAngles.y);
                }
                else
                {
                    //fireProj.gameObject.GetComponent<Shader>(). = Color.grey;
                    fireProj.gameObject.SetActive(false);
                    fireProjOff.gameObject.SetActive(true);
                    fireProjOff.gameObject.transform.position = rayInfo.point + Vector3.up * 2.5f;
                    fireProjOff.gameObject.transform.rotation = Quaternion.Euler(90, 0, -gameObject.transform.rotation.eulerAngles.y);
                }
                //fireProj.gameObject.SetActive(true);
                
                
               // knockbackProj.gameObject.SetActive(false);
                
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
            fireProjOff.gameObject.SetActive(false);
        }
        

        


        CheckSpellAvailability();
        CheckSpellLogo();
        
        if (Input.GetMouseButtonDown(0) && canCast == true)
        {
            CastSpell();
        }

        if (telekFlag == true)
        {
            if (Input.GetMouseButtonUp(0) || resource_Manager.airRune < telekCost)
            {
                telekUse = false;
                
                if (telekAnim == true)
                {
                    handAnim.Play("TelekExit");
                    telekAnim = false;
                }
            }

            if (carrying)
            {
                //Carry(carriedObject);
                
               // earthAuraL.SetActive(true);
                //earthAuraR.SetActive(true);
                if (telekUse == false)
                {
                    DropObject();
                   // earthAuraL.SetActive(false);
                   // earthAuraR.SetActive(false);
                }

                resource_Manager.airRune -= Time.deltaTime * 1.5f;
            }
            else
            {
                if (telekUse == true)
                {
                    PickUp();
                    
                    resource_Manager.airRune -= Time.deltaTime * 1.5f;
                    //earthAuraL.SetActive(true);
                   // earthAuraR.SetActive(true);
                }
            }

            if (telekUse == false)
            {
                if (telekAnim == true)
                {
                    handAnim.Play("TelekExit");
                    telekAnim = false;
                }
               // earthAuraL.SetActive(false);
               // earthAuraR.SetActive(false);
            }
        }
        else
        {
            if (carrying)
            {
                DropObject();

            }
           // earthAuraL.SetActive(false);
            //earthAuraR.SetActive(false);
        }

        if (shieldFlag == true)
        {
            
            if (Input.GetMouseButtonUp(0) || resource_Manager.waterRune < shieldCost || resource_Manager.airRune < shieldCost)
            {
                shieldUse = false;
                if (shieldAnim == true)
                {
                    handAnim.Play("ShieldExit");
                    shieldAnim = false;
                }
               // waterAuraL.SetActive(false);
               // waterAuraR.SetActive(false);
            }

            if(shieldUse == true)
            {
                
                IceShieldPrefab.SetActive(true);
                //resource_Manager.waterRune -= Time.deltaTime * 1.5f;
                //waterAuraL.SetActive(true);
                //waterAuraR.SetActive(true);

            }
            else
            {

                IceShieldPrefab.SetActive(false);
                //waterAuraL.SetActive(false);
                //waterAuraR.SetActive(false);

            }
        }
        else
        {
            shieldUse = false;
            IceShieldPrefab.SetActive(false);
            if (shieldAnim == true)
            {
                handAnim.Play("ShieldExit");
                shieldAnim = false;
            }
           // waterAuraL.SetActive(false);
            //waterAuraR.SetActive(false);

        }

        if (weldFlag == true)
        {
            
            if (Input.GetMouseButtonUp(0) || resource_Manager.fireRune < weldCost)
            {
                weldUse = false;
                if(weldAnim == true)
                {
                    handAnim.Play("WeldExit");
                    weldAnim = false;
                }
                
               // fireAuraL.SetActive(false);
               // fireAuraR.SetActive(false);

            }

            if (weldUse == true)
            {
                weldGO.SetActive(true);
                resource_Manager.fireRune -= Time.deltaTime * 1.5f;
               // fireAuraL.SetActive(true);
               // fireAuraR.SetActive(true);
            }
            else
            {
                weldGO.SetActive(false);
               // fireAuraL.SetActive(false);
               // fireAuraR.SetActive(false);
            }
        }
        else
        {
            weldUse = false;
            if (weldAnim == true)
            {
                handAnim.Play("WeldExit");
                weldAnim = false;
            }
            weldGO.SetActive(false);
            //fireAuraL.SetActive(false);
           // fireAuraR.SetActive(false);
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
        if (carriedObject == null)
        {
            telekUse = false;
            carrying = false;

        }
        if (telekFlag == true)
        {
           
            if (carrying)
            {
                Carry(carriedObject);
                
            }
        
        }
    }
    void CastSpell()
    {
        

        if (fireBallFlag == true && resource_Manager.fireRune >= fireballCost  && resource_Manager.earthRune >= fireballCost)
        {
            
            RaycastHit hit;
            if (Physics.Raycast(camera.transform.position, rayDir, out hit, spellRange))
            {
                resource_Manager.fireRune -= fireballCost;
                resource_Manager.earthRune -= fireballCost;
                handAnim.Play("Fireball");
                //Instantiate(volcano, hit.point + Vector3.up * 2.5f, Quaternion.identity);
                initialfb = new Vector3(camera.transform.position.x, camera.transform.position.y + 7.0f, camera.transform.position.z);
                finalfb = hit.point;
                Instantiate(fireballPrefab, initialfb, Quaternion.identity);
            }
        }

        if (weldFlag == true && resource_Manager.fireRune >= weldCost)
        {
            weldUse = true;
            handAnim.Play("Weld");
            weldAnim = true;
        }

        if (freezeFlag == true && resource_Manager.waterRune >= freezeCost)
        {
            resource_Manager.waterRune -= freezeCost;
            handAnim.Play("Freeze");
            Vector3 startPos = camera.transform.position ;
            Vector3 dir = reticleImage.transform.position - (startPos + Vector3.down * 0.01f);
            GameObject projectile = Instantiate(freezeEffect, startPos + Vector3.down * 0.5f, Quaternion.LookRotation(dir));
            Destroy(projectile, 1.0f);

            

        }

        if (shieldFlag == true && resource_Manager.waterRune >= shieldCost && resource_Manager.airRune >= shieldCost)
        {
            shieldUse = true;
            handAnim.Play("Shield");
            shieldAnim = true;
        }

        if (eqFlag == true && resource_Manager.earthRune >= eqCost)
        {

            resource_Manager.earthRune -= eqCost;
            handAnim.Play("Shockwave");
            if (Physics.Raycast(camera.transform.position, rayDir, out rayInfo, spellRange))
            {
                if (rayInfo.collider.gameObject.tag == "EarthSpell")
                {
                    rayInfo.collider.gameObject.GetComponent<EarthSpell>().switchGO();
                }
            }
            //GameObject knock = Instantiate(knockBackEffect, hit.point + Vector3.up * 1.0f, transform.rotation);
            //Destroy(knock, 2f);

            //GameObject knock = Instantiate(knockBackEffect);
            //knock.transform.position = transform.position;
            //colliderObj = (GameObject)Instantiate(blastCollider, transform.position, transform.rotation);
            //Destroy(knock, 5f);

            //knockBack = true;

            //GameObject knock = Instantiate(knockBackEffect);
            //SphereCollider knockSphereCollider = knock.GetComponentInChildren<SphereCollider>();

            //knock.transform.position = transform.position;

            //knockSphereCollider.enabled = true;
            //knockSphereCollider.radius += colliderIncrease * Time.deltaTime;
            //Destroy(knock, 1f);
        }

        if (telekFlag == true && resource_Manager.airRune >= telekCost)
        {
            telekUse = true;
            handAnim.Play("Telek");
            telekAnim = true;
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
        if (thrustfactor < 1f )
        {
            carried.GetComponent<Rigidbody>().velocity = Vector3.zero;
            carried.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            carried.GetComponent<Rigidbody>().AddForce(Vector3.zero, ForceMode.Force);
        }
        else
        {
            //carried.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            //float thrust = Mathf.Lerp(-1f, 1f, thrustfactor);
            carried.GetComponent<Rigidbody>().AddForce(difference * 220f , ForceMode.Force);
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
                if(carriedObject.GetComponent<TelekDmg>())
                {
                    carriedObject.GetComponent<TelekDmg>().damage = 15f; 
                }
                carriedObject.GetComponent<pickupable>().TelekEffectOn();
                
            }
        }
    }

    public void DropObject()
    {
        carrying = false;
        carriedObject.GetComponent<pickupable>().TelekEffectOff();
        carriedObject.GetComponent<Rigidbody>().useGravity = true;
        
        //carriedObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        //carriedObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        //carriedObject.GetComponent<Rigidbody>().AddForce(Vector3.zero, ForceMode.Force);
        carriedObject = null;
    }
    void CheckSpellAvailability()
    {
        if(resource_Manager.fireRune >= fireballCost && resource_Manager.earthRune >= fireballCost)
        {
            fireBallImage.sprite = fireBallSprite;
            fireBallImage.color = Color.white;
           // wheelFireballBack.fillAmount = 1;
        }
        else
        {
            fireBallImage.sprite = deactFireBallSprite;
            fireBallImage.color = Color.gray;
          //  wheelFireballBack.fillAmount = 0;
        }
        
        if (resource_Manager.fireRune >= weldCost)
        {
            weldImage.sprite = weldSprite;
            weldImage.color = Color.white;
          //  wheelWeldBack.fillAmount = 1;
        }
        else
        {
            weldImage.sprite = deactWeldSprite;
            weldImage.color = Color.gray;
          //  wheelWeldBack.fillAmount = 0;
        }

        if (resource_Manager.waterRune >= freezeCost)
        {
            freezeImage.sprite = freezeSprite;
            freezeImage.color = Color.white;
          //  wheelFreezeBack.fillAmount = 1;
        }
        else
        {
            freezeImage.sprite = deactFreezeSprite;
            freezeImage.color = Color.gray;
          //  wheelFreezeBack.fillAmount = 0;
        }

        if (resource_Manager.waterRune >= shieldCost && resource_Manager.airRune >= shieldCost)
        {
            shieldImage.sprite = shieldSprite;
            shieldImage.color = Color.white;
          //  wheelShieldBack.fillAmount = 1;
        }
        else
        {
            shieldImage.sprite = deactShieldSprite;
            shieldImage.color = Color.gray;
          //  wheelShieldBack.fillAmount = 0;
        }

        if (resource_Manager.earthRune >= eqCost)
        {
            eqImage.sprite = eqSprite;
            eqImage.color = Color.white;
           // wheelEqBack.fillAmount = 1;
        }
        else
        {
            eqImage.sprite = deactEQSprite;
            eqImage.color = Color.gray;
          //  wheelEqBack.fillAmount = 0;
        }

        if (resource_Manager.airRune >= telekCost)
        {
            telekImage.sprite = telekSprite;
            telekImage.color = Color.white;
           // wheelTelekBack.fillAmount = 1;
        }
        else
        {
            telekImage.sprite = deactTelekSprite;
            telekImage.color = Color.gray;
           // wheelTelekBack.fillAmount = 0;
        }
    }

    void CheckSpellLogo()
    {
        if (resource_Manager.fireRune >= fireballCost && resource_Manager.earthRune >= fireballCost && fireBallFlag == true)
        {
            spellLogoImage.sprite = fireBallSprite;
            spellLogoImage.color = Color.Lerp(Color.white, Color.gray, Mathf.PingPong(Time.time, 1));
            //uiBck.sprite = uiBckFire;
            //uiBck.fillAmount = 1;
           
            weldTool.SetActive(false);
            fireballTool.SetActive(true);
            freezeTool.SetActive(false);
            shieldTool.SetActive(false);
            telekTool.SetActive(false);
            eqTool.SetActive(false);
            

        }
        else if (fireBallFlag == true)
        {
            Debug.Log("fbC");
            spellLogoImage.sprite = deactFireBallSprite;
            spellLogoImage.color = Color.gray;
           // uiBck.sprite = uiBckFire;
           // uiBck.fillAmount = 0;

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
           // uiBck.sprite = uiBckFire;
           // uiBck.fillAmount = 1;

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
           // uiBck.sprite = uiBckFire;
           // uiBck.fillAmount = 0;

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
           // uiBck.sprite = uiBckWater;
           // uiBck.fillAmount = 1;

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
          //  uiBck.sprite = uiBckWater;
          //  uiBck.fillAmount = 0;

            weldTool.SetActive(false);
            fireballTool.SetActive(false);
            freezeTool.SetActive(true);
            shieldTool.SetActive(false);
            telekTool.SetActive(false);
            eqTool.SetActive(false);
        }
        if (resource_Manager.waterRune >= shieldCost && resource_Manager.airRune >= shieldCost && shieldFlag == true)
        {
            spellLogoImage.sprite = shieldSprite;
            spellLogoImage.color = Color.Lerp(Color.white, Color.gray, Mathf.PingPong(Time.time, 1));
           // uiBck.sprite = uiBckWater;
           // uiBck.fillAmount = 1;

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
           // uiBck.sprite = uiBckWater;
          //  uiBck.fillAmount = 0;

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
          //  uiBck.sprite = uiBckEarth;
          //  uiBck.fillAmount = 1;

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
          //  uiBck.sprite = uiBckEarth;
           // uiBck.fillAmount = 0;

            weldTool.SetActive(false);
            fireballTool.SetActive(false);
            freezeTool.SetActive(false);
            shieldTool.SetActive(false);
            telekTool.SetActive(false);
            eqTool.SetActive(true);
        }

        if (resource_Manager.airRune >= telekCost && telekFlag == true)
        {
            spellLogoImage.sprite = telekSprite;
            spellLogoImage.color = Color.Lerp(Color.white, Color.gray, Mathf.PingPong(Time.time, 1));
           // uiBck.sprite = uiBckAir;
           // uiBck.fillAmount = 1;

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
           // uiBck.sprite = uiBckAir;
           // uiBck.fillAmount = 0;

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

        
        HandLeft.GetComponent<SkinnedMeshRenderer>().material = earthHandL[0];
        HandRight.GetComponent<SkinnedMeshRenderer>().material = fireHandR[0];

        
    }

    public void clickOnWeld()
    {
        fireBallFlag = false;
        weldFlag = true;
        freezeFlag = false;
        shieldFlag = false;
        eqFlag = false;
        telekFlag = false;

        HandLeft.GetComponent<SkinnedMeshRenderer>().material = fireHandL[0];
        HandRight.GetComponent<SkinnedMeshRenderer>().material = fireHandR[0];
    }

    public void clickOnFreeze()
    {
        fireBallFlag = false;
        weldFlag = false;
        freezeFlag = true;
        shieldFlag = false;
        eqFlag = false;
        telekFlag = false;

        HandLeft.GetComponent<SkinnedMeshRenderer>().material = waterHandL[0];
        HandRight.GetComponent<SkinnedMeshRenderer>().material = waterHandR[0];
    }

    public void clickOnShield()
    {
        fireBallFlag = false;
        weldFlag = false;
        freezeFlag = false;
        shieldFlag = true;
        eqFlag = false;
        telekFlag = false;

        HandLeft.GetComponent<SkinnedMeshRenderer>().material = airHandL[0];
        HandRight.GetComponent<SkinnedMeshRenderer>().material = waterHandR[0];
    }

    public void clickOnEQ()
    {
        fireBallFlag = false;
        weldFlag = false;
        freezeFlag = false;
        shieldFlag = false;
        eqFlag = true;
        telekFlag = false;

        HandLeft.GetComponent<SkinnedMeshRenderer>().material = earthHandL[0];
        HandRight.GetComponent<SkinnedMeshRenderer>().material = earthHandR[0];
    }

    public void clickOnTelek()
    {
        fireBallFlag = false;
        weldFlag = false;
        freezeFlag = false;
        shieldFlag = false;
        eqFlag = false;
        telekFlag = true;

        HandLeft.GetComponent<SkinnedMeshRenderer>().material = airHandL[0];
        HandRight.GetComponent<SkinnedMeshRenderer>().material = airHandR[0];
    }


}

