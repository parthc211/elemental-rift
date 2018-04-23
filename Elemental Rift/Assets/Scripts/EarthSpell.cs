using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthSpell : MonoBehaviour {

    public GameObject rubble;
    public GameObject built;
    public GameObject effect;
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
            StaticVariablesWaterPuzzle.stoneRubbled = true;

            //dm = gameObject.GetComponentInChildren<DestoyMe>();
            //dm.destroy();
            Vector3 pos = gameObject.transform.position;
            pos.y += 1.5f;
            Instantiate(effect, gameObject.transform.position, Quaternion.Euler(90, 0, 0));
            Instantiate(built, pos, Quaternion.identity);
            //isRubble = false;
            //telekable = true;
            Destroy(gameObject);
        }
        else
        if (isRubble == false)
        {
            Vector3 pos = gameObject.transform.position;
            pos.y += 1.5f;
            Instantiate(effect, gameObject.transform.position, Quaternion.Euler(90, 0, 0));
            Instantiate(rubble, pos, Quaternion.identity);
            //isRubble = true;
            //telekable = false;
            Destroy(gameObject);

        }
    }

    
}
