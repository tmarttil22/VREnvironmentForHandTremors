using UnityEngine;

public class ProgressTracker : MonoBehaviour
{


    public GameObject drawTaskScript;
    public GameObject sortTaskScript;

    public GameObject serveTaskScript;

    public CheckDirtyDishes fillDishwasherScript;

    public CheckDishes emptyDishwasherScript;


    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if(checkGameCompletion()){
            gameFinished();
        }
    }

    bool checkGameCompletion(){
        if(fillDishwasherScript.targetZoneFull && emptyDishwasherScript.targetZoneFull){
            return true;
        }
        return false;
    }

    void gameFinished(){
//show some ui element
    }
}
