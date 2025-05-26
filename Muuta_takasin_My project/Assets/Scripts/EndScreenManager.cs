using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
public class EndScreenManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject jobMenu;

    public GameObject playerHead;
    public bool menuShown;

    //menu ui 
    public Button quitButton;
    public Button resumeButton;
    public Button restartButton;



    void Start()
    {
        menuShown = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (menuShown)
        {
            menuOrientation();
            menuShown = false;
            StartCoroutine(showJobEnd());
        }
    }
    void menuOrientation()
    {
        jobMenu.transform.position =
        playerHead.transform.position +
        new Vector3(playerHead.transform.forward.x, 0, playerHead.transform.forward.z) * 1;
        jobMenu.transform.LookAt(playerHead.transform.position, Vector3.up);
        jobMenu.transform.forward *= -1;
    }


    IEnumerator showJobEnd()
    {
        jobMenu.SetActive(true);
        yield return new WaitForSeconds(10);
        jobMenu.SetActive(false);
        yield break;          
    }

    
    public void showGameFinished()
    {
        
    }

}
