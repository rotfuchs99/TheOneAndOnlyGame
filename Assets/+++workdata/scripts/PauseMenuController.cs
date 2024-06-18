using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pausemenu : MonoBehaviour
{
    private PlayerInput playercontrols;
    
    //has access to the new input system in the "menu" folder
    private InputAction menu;

    [SerializeField] private CanvasGroup pauseUI;
    [SerializeField] private bool isPaused;

    [SerializeField] private Button ExittoMenuBUtton;
    [SerializeField] private Button ContinueBUtton;
    [SerializeField] private Button SettingsBUtton;
    [SerializeField] private string nameMenuScene;

    // Start is called before the first frame update
    void Awake()
    {
        ExittoMenuBUtton.onClick.AddListener(backtomenu);
        ContinueBUtton.onClick.AddListener(DeactivateMenu);
        playercontrols = new PlayerInput();
        pauseUI.HideCanvasGroup();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnEnable()
    {
        //game will be paused, when menu is opened
        menu = playercontrols.Interactions.PauseMenu;
        menu.Enable();

        menu.performed += Pause;
    }

    private void OnDisable()
    {
        menu.Disable();
    }

    void Pause(InputAction.CallbackContext context)
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            ActivateMenu();
        }
        else
        {
            DeactivateMenu();
        }

    }

    void ActivateMenu()
    {
        //time to 0 and showing the menu
        Time.timeScale = 0;
        pauseUI.ShowCanvasGroup();
    }

    public void DeactivateMenu()
    {
        //time back to 1 and hiding the menu
        Time.timeScale = 1;
        pauseUI.HideCanvasGroup();
        isPaused = false;
    }
    void backtomenu()
    {
        //load main menu
        SceneManager.LoadScene(nameMenuScene);
    }
}