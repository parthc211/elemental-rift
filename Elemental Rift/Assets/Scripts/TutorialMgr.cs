using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialMgr : MonoBehaviour {

    public GameObject spell;

    public GameObject textBox;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(textBox.activeInHierarchy == true)
        {
            if (Input.GetMouseButtonDown(1))
            {
                textBox.SetActive(false);
                gameObject.SetActive(false);
            }
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            spell.SetActive(true);
            textBox.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }
}
