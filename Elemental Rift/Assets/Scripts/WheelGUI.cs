using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class WheelGUI : MonoBehaviour {

    public GameObject wheel;

    private bool showWheelGUI = false;

    private Input_Manager im;
    //private RigidbodyFirstPersonController rigidFPS;
    // Use this for initialization
    void Start () {
        wheel.gameObject.SetActive(false);
        //rigidFPS = GetComponent<RigidbodyFirstPersonController>();
        im = GetComponent<Input_Manager>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            wheel.gameObject.SetActive(true);
            //rigidFPS.enabled = false;
            im.canCast = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = false;
            Time.timeScale = 0.0f;
            
        }

        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            wheel.gameObject.SetActive(false);
            im.canCast = true;
            //rigidFPS.enabled = true;
            Time.timeScale = 1.0f;
        }
    }

}
