using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour 
{

    public Player player;
    public GameObject loadScreen;
    public GameObject fadePanel;
    public GameObject mainMenu;
    public GameObject alienInvaders;
    public GameObject lazerEyeballs;

    public GameObject alienInvadersEasy;
    public GameObject alienInvadersMedium;
    public GameObject alienInvadersHard;

    public GameObject lazerEyeballsEasy;
    public GameObject lazerEyeballsMedium;
    public GameObject lazerEyeballsHard;

    static private GameType currentGameType;
    public enum GameType { AlienInvaders, LazerEyeballs};

    static private int score;
    private bool gameOver;

	// Use this for initialization
	void Start () 
    {
        loadScreen.SetActive(true);
        mainMenu.SetActive(false);
        alienInvaders.SetActive(false);
        Invoke("ActivateMainMenu", 3f);
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    #region GAME MANAGEMENT
    public void SetGameOver(bool toSet)
    {
        gameOver = toSet;
    }

    public bool GetGameOver()
    {
        return gameOver;
    }

    static public GameType GetCurrentGameType()
    {
        return currentGameType;
    }

    public void ActivateMainMenu()
    {
        // this is transition from end of game
        if (gameOver)
        {
            fadePanel.SetActive(true);
            Invoke("GamesToMenu", 3f);
        }

        // this is initial load
        else
        {
            GamesToMenu();
        }

        //player.Recenter();
    }

    private void GamesToMenu()
    {
        fadePanel.SetActive(false);
        DeactivateAllGames();
        loadScreen.SetActive(false);
        mainMenu.SetActive(true);
    }

    private void InitializeGame()
    {
        SetScore(0);
    }

    private void DeactivateAllGames()
    {
        alienInvaders.SetActive(false);
        alienInvadersEasy.SetActive(false);
        alienInvadersMedium.SetActive(false);
        alienInvadersHard.SetActive(false);

        lazerEyeballs.SetActive(false);
        lazerEyeballsEasy.SetActive(false);
        lazerEyeballsMedium.SetActive(false);
        lazerEyeballsHard.SetActive(false);
    }

    public void Quit()
    {
        Debug.Log("Quit");
        if (mainMenu.activeSelf == true)
        {
            Application.Quit();
        }
        else
        {
            ActivateMainMenu();
        }
    }
    #endregion

    #region HIGH SCORE TRACKING

    static public void AddToScore(int toAdd)
    {
        score += toAdd;
    }

    static public int GetScore()
    {
        return score;
    }

    static public void SetScore(int toSet)
    {
        score = toSet;
    }

    #endregion

    #region ALIEN INVADERS
    public void StartAlienInvaders()
    {
        //Debug.Log("Play alien invaders");
        currentGameType = GameType.AlienInvaders;
        mainMenu.SetActive(false);
        alienInvaders.SetActive(true);
        InitializeGame();
    }

    public void StartAlienInvadersEasy()
    {
        alienInvadersEasy.SetActive(true);
        alienInvadersMedium.SetActive(false);
        alienInvadersHard.SetActive(false);
        StartAlienInvaders();
    }

    public void StartAlienInvadersMedium()
    {
        alienInvadersEasy.SetActive(true); 
        alienInvadersMedium.SetActive(true);
        alienInvadersHard.SetActive(false);
        StartAlienInvaders();
    }

    public void StartAlienInvadersHard()
    {
        alienInvadersEasy.SetActive(true);
        alienInvadersMedium.SetActive(true);
        alienInvadersHard.SetActive(true);
        StartAlienInvaders();
    }
    #endregion

    #region LAZER EYEBALLS
    public void StartLazerEyeballs()
    {
        //Debug.Log("Play lazer eyeballs");
        currentGameType = GameType.LazerEyeballs;
        mainMenu.SetActive(false);
        lazerEyeballs.SetActive(true);
        InitializeGame();
        int scoreIncrementRate = 1;
        InvokeRepeating("IncrementScoreByOne", scoreIncrementRate, scoreIncrementRate);
    }

    public void StartLazerEyeballsEasy()
    {
        lazerEyeballsEasy.SetActive(true);
        lazerEyeballsMedium.SetActive(false);
        lazerEyeballsHard.SetActive(false);
        StartLazerEyeballs();
    }

    public void StartLazerEyeballsMedium()
    {
        lazerEyeballsEasy.SetActive(true); 
        lazerEyeballsMedium.SetActive(true);
        lazerEyeballsHard.SetActive(false);
        StartLazerEyeballs();
    }

    public void StartLazerEyeballsHard()
    {
        lazerEyeballsEasy.SetActive(true);
        lazerEyeballsMedium.SetActive(true);
        lazerEyeballsHard.SetActive(true);
        StartLazerEyeballs();
    }

    private void IncrementScoreByOne()
    {
        AddToScore(1);
    }

    #endregion
}
