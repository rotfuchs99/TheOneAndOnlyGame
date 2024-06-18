using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [Header("Main")] //for the organisation
    [SerializeField] private CanvasGroup canvasGroupMain;

    [SerializeField] private Button buttonNewGame;
    [SerializeField] private Button buttonSelectLevel;
    [SerializeField] private Button buttonExit;
    
    //Header for the Level Selection
    [Header("LevelSelection")] 
    [SerializeField] private CanvasGroup canvasGroupLevelSelection;

    [SerializeField] private Button buttonBack;
    [SerializeField] private Button buttonLevel1;
    [SerializeField] private Button buttonLevel2;
    [SerializeField] private Button buttonLevel3;
    [SerializeField] private Button buttonLevel4;
    [SerializeField] private Button buttonLevel5;
    //still in level selection but for assigning levels in inspector
    [SerializeField] private string[] sceneNamesLevel;
    
    // Start is called before the first frame update
    void Start()
    {
        canvasGroupMain.ShowCanvasGroup();
        canvasGroupLevelSelection.HideCanvasGroup();
        
        // AddListener "listens" if button was clicked
        buttonNewGame.onClick.AddListener(StartNewGame); 
        buttonBack.onClick.AddListener(BackToMain);
        buttonExit.onClick.AddListener(ExitGame);
        buttonSelectLevel.onClick.AddListener(ShowLevelSelection);

        buttonLevel1.onClick.AddListener(LoadLevel1); 
        buttonLevel2.onClick.AddListener(LoadLevel2);
        buttonLevel3.onClick.AddListener(LoadLevel3);
        buttonLevel4.onClick.AddListener(LoadLevel4);
        buttonLevel5.onClick.AddListener(LoadLevel5);

        //same as deactivating interactability (checkmark) in unity //=is deactivated prior
        buttonLevel2.interactable = false; 
        // HasKey checks if there's something saved by that name
        if (PlayerPrefs.HasKey(sceneNamesLevel[1])) 
        {
            // ("==1" functions a bit ike "true" here -> int)
            if (PlayerPrefs.GetInt(sceneNamesLevel[1]) == 1) 
            {
                //if scene 2 was loaded, level 2 button becomes interactable
                buttonLevel2.interactable = true;  
            }
        }

        buttonLevel3.interactable = false; 
        if (PlayerPrefs.HasKey(sceneNamesLevel[2]))
        {
            if (PlayerPrefs.GetInt(sceneNamesLevel[2]) == 1)
            {
                buttonLevel3.interactable = true; 
            }
        }  
        
        buttonLevel4.interactable = false; 
        if (PlayerPrefs.HasKey(sceneNamesLevel[3]))
        {
            if (PlayerPrefs.GetInt(sceneNamesLevel[3]) == 1)
            {
                buttonLevel4.interactable = true; 
            }
        }  
        
        buttonLevel5.interactable = false; 
        if (PlayerPrefs.HasKey(sceneNamesLevel[4]))
        {
            if (PlayerPrefs.GetInt(sceneNamesLevel[4]) == 1)
            {
                buttonLevel5.interactable = true; 
            }
        }    
    }
    
    
    //LoadLevel1
    void StartNewGame() 
    {
        SceneManager.LoadScene(sceneNamesLevel[0]);   //level 1 = 0, level 2 = 1, ...
    }
    void LoadLevel1() 
    {
        SceneManager.LoadScene(sceneNamesLevel[0]);  
        Debug.Log(true);
    }

    void LoadLevel2()
    {
        SceneManager.LoadScene(sceneNamesLevel[1]);
    }

    void LoadLevel3()
    {
        SceneManager.LoadScene(sceneNamesLevel[2]);
    }

    void LoadLevel4()
    {
        SceneManager.LoadScene(sceneNamesLevel[3]);
    }
    
    void LoadLevel5()
    {
        SceneManager.LoadScene(sceneNamesLevel[4]);
    }
    
    //for level selection menu
    void ShowLevelSelection() 
    {
        //hides main menu
        canvasGroupMain.HideCanvasGroup(); 
        canvasGroupLevelSelection.ShowCanvasGroup();
    }

    void ExitGame()
    {
        //quits everything
        Application.Quit(); 
    }

    void BackToMain()
    {
        canvasGroupMain.ShowCanvasGroup();
        canvasGroupLevelSelection.HideCanvasGroup();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
