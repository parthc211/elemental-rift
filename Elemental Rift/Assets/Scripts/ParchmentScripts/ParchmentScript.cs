using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParchmentScript : MonoBehaviour {

    public GameObject Canvas_Notes;

    public GameObject CanvasNoteImage1;
    public GameObject CanvasNoteImage2;
    public GameObject CanvasNoteImage3;
    public GameObject CanvasNoteImage4;
    public GameObject CanvasNoteImage5;

  
    //public Sprite Canvas_Note1;
    //public Sprite Canvas_Note2;
    //public Sprite Canvas_Note3;
    //public Sprite Canvas_Note4;
    //public Sprite Canvas_Note5;

    

    public Text Canvas_Text;

	// Use this for initialization
	void Start () {
        //CanvasNoteImage = Canvas_Notes.GetComponent<Image>();

    }
	
	// Update is called once per frame
	void Update () {
		
        if(CanvasNoteImage1.activeInHierarchy==true ||
           CanvasNoteImage2.activeInHierarchy == true ||
           CanvasNoteImage3.activeInHierarchy == true ||
           CanvasNoteImage4.activeInHierarchy == true ||
           CanvasNoteImage5.activeInHierarchy == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Time.timeScale = 1f;
                Canvas_Notes.SetActive(false);
                

            }
        }


	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Note")
        {
            Canvas_Notes.SetActive(true);

            switch (other.gameObject.name)
            {
                case "Note1":
                    CanvasNoteImage1.SetActive(true);
                    CanvasNoteImage2.SetActive(false);
                    CanvasNoteImage3.SetActive(false);
                    CanvasNoteImage4.SetActive(false);
                    CanvasNoteImage5.SetActive(false);
                    //CanvasNoteImage.sprite = Canvas_Note1;
                    Destroy(other.gameObject);
                    Time.timeScale = 0f;

                    Debug.Log("1");
                    //Canvas_Text.text = "For thousands of years mages have faced their death in this area. The guild tested the mettle of their students in this arena named The 'Proving Grounds'. Whether the candidate is just starting their adventures or is being punished, this arena treats them all alike.";
                    break;

                case "Note2":
                    CanvasNoteImage1.SetActive(false);
                    CanvasNoteImage2.SetActive(true);
                    CanvasNoteImage3.SetActive(false);
                    CanvasNoteImage4.SetActive(false);
                    CanvasNoteImage5.SetActive(false);
                    //CanvasNoteImage.sprite = Canvas_Note2;
                    Destroy(other.gameObject);
                    Time.timeScale = 0f;
                    Debug.Log("2");
                    //Canvas_Text.text = "When the powers of the kingdom were at its peak, the skies of the temple used to fill with the sounds of creatures. The temple used to stand tall in front of the lake of magical waters. This oasis is what remains of the once great lake.";
                    break;

                case "Note3":
                    CanvasNoteImage1.SetActive(false);
                    CanvasNoteImage2.SetActive(false);
                    CanvasNoteImage3.SetActive(true);
                    CanvasNoteImage4.SetActive(false);
                    CanvasNoteImage5.SetActive(false);
                    //CanvasNoteImage.sprite = Canvas_Note3;
                    Destroy(other.gameObject);
                    Time.timeScale = 0f;
                    Debug.Log("3");
                    break;

                case "Note4":
                    CanvasNoteImage1.SetActive(false);
                    CanvasNoteImage2.SetActive(false);
                    CanvasNoteImage3.SetActive(false);
                    CanvasNoteImage4.SetActive(true);
                    CanvasNoteImage5.SetActive(false);
                    // CanvasNoteImage.sprite = Canvas_Note4;
                    Destroy(other.gameObject);
                    Time.timeScale = 0f;
                    Debug.Log("4");
                    break;

                case "Note5":
                    CanvasNoteImage1.SetActive(false);
                    CanvasNoteImage2.SetActive(false);
                    CanvasNoteImage3.SetActive(false);
                    CanvasNoteImage4.SetActive(false);
                    CanvasNoteImage5.SetActive(true);
                    //CanvasNoteImage.sprite = Canvas_Note5;
                    Destroy(other.gameObject);
                    Time.timeScale = 0f;
                    Debug.Log("5");
                    break;
            };

        }
    }



        /*
        if (other.gameObject.tag=="Note")
        {
            Canvas_Notes.SetActive(true);
            Canvas_Text.text = "Found a note!: " + other.gameObject.name;
           // Debug.Log("Found a note!: " + other.gameObject.name);         
            Destroy(other.gameObject);
           
        } */





    }






