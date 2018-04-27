using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParchmentScript : MonoBehaviour {

    public GameObject Canvas_Notes;
    public Text Canvas_Text;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Note")
        {
            Canvas_Notes.SetActive(true);

            switch (other.gameObject.name)
            {
                case "Note1":
                    Debug.Log("1");
                    Canvas_Text.text = "For thousands of years mages have faced their death in this area. The guild tested the mettle of their students in this arena named The 'Proving Grounds'. Whether the candidate is just starting their adventures or is being punished, this arena treats them all alike.";
                    break;
                case "Note2":
                    Debug.Log("2");
                    Canvas_Text.text = "When the powers of the kingdom were at its peak, the skies of the temple used to fill with the sounds of creatures. The temple used to stand tall in front of the lake of magical waters. This oasis is what remains of the once great lake.";
                    break;
                case "Note3":
                    Debug.Log("3");
                    break;
                case "Note4":
                    Debug.Log("4");
                    break;
                case "Note5":
                    Debug.Log("5");
                    break;
            };
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




}






