using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tutEndScreen : MonoBehaviour {

    public GameObject screen1;
    public GameObject screen2;
    public GameObject screen3;
    public GameObject screen4;

    bool isBegin = false;
    float timer = 0.0f;

    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isBegin)
        {
            timer += Time.deltaTime;

            if(timer >= 2 && timer < 6)
            {
                screen1.SetActive(true);
                gameObject.GetComponent<AudioSource>().Play();
            } 
            if (timer >= 6 && timer < 10)
            {
                screen1.SetActive(false);
                screen2.SetActive(true);
            }
            if (timer >= 10 && timer < 14)
            {
                screen2.SetActive(false);
                screen3.SetActive(true);
            }

            if (timer >= 14 && timer < 18)
            {
                screen3.SetActive(false);
                screen4.SetActive(true);
            }
            if(timer >= 18)
            {
                SceneManager.LoadScene("Prototype_Earth_Level");
            }

        }
    }

    public void StartEndScreen()
    {
        isBegin = true;
    }
}
