using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasStart;
    [SerializeField] private CanvasGroup canvasWin;
    [SerializeField] private CanvasGroup canvasLost;

    [SerializeField] private Button buttonStartGame;
    [SerializeField] private Button buttonPlayAgain;
    [SerializeField] private Button buttonPlayAgainLost;

    [SerializeField] private Button buttonNextLevel;

    [Header("Scene Loading")] [SerializeField]
    private string nameNextLevel;


    private void Start()
    {
        //let time freeze - only input is working - no physics or updates
        Time.timeScale = 0f;
        
        ShowCanvasGroup(canvasStart);
        HideCanvasGroup(canvasWin);
        HideCanvasGroup(canvasLost);
        
        buttonStartGame.onClick.AddListener(StartGame);
        buttonPlayAgain.onClick.AddListener(ReloadCurrentScene);
        buttonPlayAgainLost.onClick.AddListener(ReloadCurrentScene);
        
        buttonNextLevel.onClick.AddListener(LoadNextLevel);
    }

    void StartGame()
    {
        //set timescale back to normal
        Time.timeScale = 1f;
        HideCanvasGroup(canvasStart);
    }

    public void GameLost()
    {
        Time.timeScale = 0f;
        ShowCanvasGroup(canvasLost);
    }

    public void GameWin()
    {
        Time.timeScale = 0f;
        ShowCanvasGroup(canvasWin);
    }

    void LoadNextLevel()
    {
        SceneManager.LoadScene(nameNextLevel);
    }

    void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    void ShowCanvasGroup(CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }
    
    void HideCanvasGroup(CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 0f;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }

    public void StartGameButton()
    {
        HideCanvasGroup(canvasStart);
        HideCanvasGroup(canvasWin);
        HideCanvasGroup(canvasLost);
    }

}
