using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cutscenetransition : MonoBehaviour {
    float timer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if(timer >= 31.0f)
        {
            SceneManager.LoadScene("Prototype_Earth_Level");
        }
	}
}
