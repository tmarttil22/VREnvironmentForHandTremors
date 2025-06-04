using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenuManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    /*This class adds functionality to the game menu which controlls behaviour of restart, resume and quit buttons.*/
    public GameObject menu;
    public GameObject playerHead;
    bool menuShown;
    public InputActionProperty menuButton;

    public GameObject raycasterLeft;
    public GameObject raycasterRight;
    //menu ui 
    public Button quitButton;
    public Button resumeButton;
    public Button restartButton;



    void Start()
    {
        menuShown = false;
        /*Add listeners for the buttons so callback is activated to the corresponding function when needed.*/
        quitButton.onClick.AddListener(TaskOnClick_Quit);
        resumeButton.onClick.AddListener(TaskOnClick_Resume);
        restartButton.onClick.AddListener(TaskOnClick_Restart);
    }

    // Update is called once per frame
    void Update()
    {
        if (menuButton.action.WasPressedThisFrame())
        {
            menuOrientation();
            menu.SetActive(!menu.activeSelf);
            raycasterLeft.SetActive(!raycasterLeft.activeSelf);
            raycasterRight.SetActive(!raycasterRight.activeSelf);
        }

    }
/*This function shuts down the Unity application. If application is running in Unity editor then editor shuts down with the compiler command.*/
    void TaskOnClick_Quit()
    {
        Application.Quit();
    #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
    #endif
    }
    /*This function hides the game menu.*/
    void TaskOnClick_Resume()
    {
        menu.SetActive(!menu.activeSelf);
        raycasterLeft.SetActive(!raycasterLeft.activeSelf);
        raycasterRight.SetActive(!raycasterRight.activeSelf);
    }
    /*Calling this fucntion reloads and restarts the current scene in the unity. */
    void TaskOnClick_Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    /*This method checks orientation and sets distance for the menu if MENU-button is pressed.*/
    void menuOrientation()
    {
        menu.transform.position =
        playerHead.transform.position +
        new Vector3(playerHead.transform.forward.x, 0, playerHead.transform.forward.z) * 1;
        menu.transform.LookAt(playerHead.transform.position, Vector3.up);
        menu.transform.forward *= -1;
    }

    

}
