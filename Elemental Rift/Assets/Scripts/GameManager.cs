using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public AudioSource buttonClickAudio;

    public GameObject mainScreen;
    public GameObject instructionsScreen;
    public GameObject creditsScreen;

    private void Awake()
    {
        mainScreen.SetActive(true);
        instructionsScreen.SetActive(false);
        creditsScreen.SetActive(false);
    }
    void Start ()
    {
		
	}
	

	void Update ()
    {
		
	}

    public void OnClickPlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void OnClickInstructionButton()
    {
        mainScreen.SetActive(false);
        instructionsScreen.SetActive(true);
        creditsScreen.SetActive(false);
    }

    public void OnClickCreditsButton()
    {
        mainScreen.SetActive(false);
        instructionsScreen.SetActive(false);
        creditsScreen.SetActive(true);
    }

    public void OnClickExitButton()
    {
        Application.Quit();
    }

    public void OnClickBackButton()
    {
        mainScreen.SetActive(true);
        instructionsScreen.SetActive(false);
        creditsScreen.SetActive(false);
    }

    public void OnButtonClickAudio()
    {
        buttonClickAudio.Play();
    }
}
