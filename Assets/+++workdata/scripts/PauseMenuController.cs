using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pausemenu : MonoBehaviour
{
    private PlayerInput playercontrols;
    //greifft auf das neue input system im "menu" ordner zu
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
        //spiel wird pausiert wenn das menu geöffnet wird 
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
        //zeit auf 0 und menu anzeigen
        Time.timeScale = 0;
        pauseUI.ShowCanvasGroup();
    }

    public void DeactivateMenu()
    {
        //zeit wieder auf 1 und menu ausschalten
        Time.timeScale = 1;
        pauseUI.HideCanvasGroup();
        isPaused = false;
    }
    void backtomenu()
    {
        //loadmainmenu
        SceneManager.LoadScene(nameMenuScene);
    }
}