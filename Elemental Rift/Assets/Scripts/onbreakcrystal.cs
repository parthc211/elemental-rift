using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class onbreakcrystal : MonoBehaviour {

    float timer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if(timer > 3.0f)
        {
            SceneManager.LoadScene("Cutscene");
        }

    }
}
