using UnityEngine;

public class ProgressTracker : MonoBehaviour
{


    public CheckDrawings drawTaskScript;
    public CheckSorting sortTaskScript;

    public HoloTaskHandler serveTaskScript;

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
        if(fillDishwasherScript.targetZoneFull 
        && emptyDishwasherScript.targetZoneFull
        && sortTaskScript.IsSortingCompleted()
        && drawTaskScript.IsDrawingCompleted()
        && serveTaskScript.IsServingCompleted()
        ){
            return true;
        }
        return false;
    }

    void gameFinished(){
        Debug.Log("DEBUG: TASKS COMPLETED");
        //show some ui element or play sound?
        //save data and stuff?
    }
}
