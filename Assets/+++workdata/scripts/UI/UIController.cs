using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    //serializedFields are there to see everything in the inspector
    //so in the inspector you will see the canvas start, canvas win and all the other serialized fields you see beneath them
    [SerializeField] private CanvasGroup canvasStart;
    [SerializeField] private CanvasGroup canvasWin;
    [SerializeField] private CanvasGroup canvasLost;

    [SerializeField] private Button buttonStartGame;
    [SerializeField] private Button buttonPlayAgain;
    [SerializeField] private Button buttonPlayAgainLost;

    [SerializeField] private Button buttonNextLevel;
    [SerializeField] private Button buttonBackToMenu;
    
    //the coincounter is there to count the coins you will collect throughout the gameplay
    //the header is there, so you can see what you are working on in for example the scene loading area
    private int coincounter = 0;
    [SerializeField] private TextMeshProUGUI txtcoincount;
    
    [Header("Scene Loading")] [SerializeField]
    private string nameNextLevel;


    private void Start()
    {
        //let time freeze - only input is working - no physics or updates
        Time.timeScale = 0f;
        
        canvasStart.ShowCanvasGroup();
        canvasWin.HideCanvasGroup();
        canvasLost.HideCanvasGroup();
        
        buttonStartGame.onClick.AddListener(StartGame);
        buttonPlayAgain.onClick.AddListener(ReloadCurrentScene);
        buttonPlayAgainLost.onClick.AddListener(ReloadCurrentScene);
        buttonBackToMenu.onClick.AddListener(BackToMenu);
        
        buttonNextLevel.onClick.AddListener(LoadNextLevel);
    }

    
    void StartGame()
    {
        //set timescale back to normal
        Time.timeScale = 1f;
        canvasStart.HideCanvasGroup();
    }
    
    
    //0 means that the time is stopped
    public void GameLost()
    {
        Time.timeScale = 0f;
        canvasLost.ShowCanvasGroup();
    }
    
    
    //the screen for the next level is shown
    public void GameWin()
    {
        Time.timeScale = 0f;
        PlayerPrefs.SetInt(nameNextLevel,1);
        canvasWin.ShowCanvasGroup();
    }

    
    void LoadNextLevel()
    {
        SceneManager.LoadScene(nameNextLevel);
    }
    //This stands for a button that brings you back to the main menu
    void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
        Debug.Log(true);
    }

    void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    
    //as the game starts, the win canvas and the lost canvas are hidden, so the game can start, and the player ism't interrupted by other screens
    public void StartGameButton()
    {
        canvasStart.HideCanvasGroup();
        canvasWin.HideCanvasGroup();
        canvasLost.HideCanvasGroup();
    }
    
    public void AddCoin()
    {
        
        coincounter++;
        txtcoincount.text = coincounter.ToString();
    }

    
}
public static class ExtentionMethod
{
    public static void ShowCanvasGroup(this CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }
    public static void HideCanvasGroup(this CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 0f;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }
}