using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasStart;
    [SerializeField] private CanvasGroup canvasWin;
    [SerializeField] private CanvasGroup canvasLost;

    [SerializeField] private Button buttonStartGame;
    [SerializeField] private Button buttonPlayAgain;
    [SerializeField] private Button buttonPlayAgainLost;

    [SerializeField] private Button buttonNextLevel;
    [SerializeField] private Button buttonBackToMenu;
    
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

    public void GameLost()
    {
        Time.timeScale = 0f;
        canvasLost.ShowCanvasGroup();
    }

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
    
    void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
        Debug.Log(true);
    }

    void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    

    public void StartGameButton()
    {
        canvasStart.HideCanvasGroup();
        canvasWin.HideCanvasGroup();
        canvasLost.HideCanvasGroup();
    }
    
    public void AddCoin()
    {
        //wenn coin eingesammlt dann wird er in dem panel zu den anderen hinzugefügt
        coincounter++; //coincount++; same as coincount = coincount +1;
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