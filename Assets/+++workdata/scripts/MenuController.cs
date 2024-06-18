using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] private string[] sceneNameLevel;
    
    // Start is called before the first frame update
    void Start()
    {
        canvasGroupMain.ShowCanvasGroup();
        canvasGroupLevelSelection.HideCanvasGroup();

        buttonNewGame.onClick.AddListener(StartNewGame); // AddListener "listens" if button was clicked
        buttonBack.onClick.AddListener(BackToMain);
        buttonExit.onClick.AddListener(ExitGame);
        buttonSelectLevel.onClick.AddListener(ShowLevelSelection);

        buttonLevel1.onClick.AddListener(StartNewGame); 
        buttonLevel2.onClick.AddListener(LoadLevel2);
        buttonLevel3.onClick.AddListener(LoadLevel3);
        buto

        buttonLevel2.interactable = false; //same as deactivating interactability (checkmark) in unity //=is deactivated prior
        if (PlayerPrefs.HasKey(sceneNamesLevel[1])) // HasKey checks if there's something saved by that name
        {
            if (PlayerPrefs.GetInt(sceneNamesLevel[1]) == 1) // ("==1" functions a bit ike "true" here -> int)
            {
                buttonLevel2.interactable = true;  //if scene 2 was loaded, level 2 button becomes interactable
            }
        }

        buttonLevel3.interactable = false; 
        if (PlayerPrefs.HasKey(sceneNamesLevel[2]))
        {
            if (PlayerPrefs.GetInt(sceneNamesLevel[2]) == 1)
            {
                buttonLevel2.interactable = true; 
            }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
