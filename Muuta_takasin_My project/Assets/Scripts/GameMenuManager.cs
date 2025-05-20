using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GameMenuManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject menu;
    public GameObject playerHead;
    bool menuShown;
    public InputActionProperty menuButton;

    //menu ui 
    public Button quitButton;
    public Button resumeButton;
    public Button restartButton;


    void Start()
    {
        menuShown = false;
        Button quit_button = gameObject.GetComponent<Button>();
        quit_button.onClick.AddListener(TaskOnClick_Quit);

        Button resume_button = gameObject.GetComponent<Button>();
        resume_button.onClick.AddListener(TaskOnClick_Resume);

        Button restart_button = gameObject.GetComponent<Button>();
        restart_button.onClick.AddListener(TaskOnClick_Restart);
    }

    // Update is called once per frame
    void Update()
    {
        if (menuButton.action.WasPressedThisFrame())
        {
            menuOrientation();
            menu.SetActive(!menu.activeSelf);
        }

    }

    void TaskOnClick_Quit()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
     void TaskOnClick_Resume()
    {
        menu.SetActive(!menu.activeSelf);
    }
    void TaskOnClick_Restart()
    {
        
    }

    void menuOrientation()
    {
        menu.transform.position =
        playerHead.transform.position +
        new Vector3(playerHead.transform.forward.x, 0, playerHead.transform.forward.z) * 1;
        menu.transform.LookAt(playerHead.transform.position, Vector3.up);
        menu.transform.forward *= -1;
    }

    

}
