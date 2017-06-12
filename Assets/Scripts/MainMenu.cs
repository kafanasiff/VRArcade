using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public Text alienInvadersScoreText;
    public Text lazerEyeballsScoreText;

	// Use this for initialization
	void Start () 
    {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    void OnEnable()
    {
        alienInvadersScoreText.text = PlayerPrefs.GetInt("AlienInvaders").ToString();
        lazerEyeballsScoreText.text = PlayerPrefs.GetInt("LazerEyeballs").ToString();
    }
}
