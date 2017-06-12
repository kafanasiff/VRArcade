using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienInvaders : MonoBehaviour {

    public GameManager manager;
    public GameObject[] enemies;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
        
    public void GameOver()
    {
        if (GameManager.GetScore() > PlayerPrefs.GetInt("AlienInvaders"))
        {
            PlayerPrefs.SetInt("AlienInvaders", GameManager.GetScore());
        }
        manager.SetGameOver(true);
        manager.ActivateMainMenu();
    }
}
