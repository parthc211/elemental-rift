using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthSpell : MonoBehaviour {

    public GameObject rubble;
    public GameObject built;

    public bool isRubble = false;
    public bool telekable = false;

    DestoyMe dm;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    public void switchGO()
    {
        if(isRubble == true)
        {

            //dm = gameObject.GetComponentInChildren<DestoyMe>();
            //dm.destroy();
            
            Instantiate(built, gameObject.transform.position, Quaternion.identity);
            isRubble = false;
            telekable = true;
            Destroy(gameObject);
        }
        else
        if (isRubble == false)
        {

            Instantiate(rubble, gameObject.transform.position, Quaternion.identity);
            isRubble = true;
            telekable = false;
            Destroy(gameObject);

        }
    }

    
}
