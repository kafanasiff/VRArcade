using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour {

    private bool musicIsOn;
    public Toggle musicToggle;
    public AudioSource musicSource;

	// Use this for initialization
	void Start () {
        if (PlayerPrefs.GetString("Music") == "Off")
        {
            musicIsOn = false;
            musicToggle.isOn = false;
        }
        else
        {
            musicIsOn = true;
            musicToggle.isOn = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ToggleMusic()
    {
        Debug.Log("Toggle music");
        if (musicIsOn)
        {
            musicToggle.isOn = false;
            musicSource.Stop();
            musicIsOn = false;
            PlayerPrefs.SetString("Music", "Off");
        }
        else
        {
            musicToggle.isOn = true;
            musicSource.Play();
            musicIsOn = true;
            PlayerPrefs.SetString("Music", "On");
        }
    }

    public void ChangeVolume()
    {
        Debug.Log("Change volume");
    }
}
