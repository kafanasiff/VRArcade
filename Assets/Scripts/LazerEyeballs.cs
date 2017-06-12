using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerEyeballs : MonoBehaviour {

    public GameManager manager;
    public Eye[] eyes;

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }

    public void GameOver()
    {
        foreach (Eye eye in eyes)
        {
            eye.StopFiringLasers();
        }
        CancelInvoke("IncrementScoreByOne"); // this is invoked in GameManager -> InitializeGame
        if (GameManager.GetScore() > PlayerPrefs.GetInt("LazerEyeballs"))
        {
            PlayerPrefs.SetInt("LazerEyeballs", GameManager.GetScore());
        }
        manager.SetGameOver(true);
        manager.ActivateMainMenu();
    }
}
