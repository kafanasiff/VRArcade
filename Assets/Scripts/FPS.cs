using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPS : MonoBehaviour {

    public GameObject FPSCanvas; 
    public Toggle toggle;
    private bool isOn = false;

	// Use this for initialization
	void Start () {
        FPSCanvas.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ToggleFPS()
    {
        Debug.Log("Toggle FPS");
        if (isOn)
        {
            FPSCanvas.SetActive(false);
            toggle.isOn = false;
            isOn = false;
        }
        else
        {
            FPSCanvas.SetActive(true);
            toggle.isOn = true;
            isOn = true;
        }
    }
}
