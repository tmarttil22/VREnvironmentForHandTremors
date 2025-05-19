using UnityEngine;

public class ProgressTracker : MonoBehaviour
{


    public CheckDrawings drawTaskScript;
    public CheckSorting sortTaskScript;

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
//1 cleansdishes
    public bool checkStartOfCleanDishes(){
        if(emptyDishwasherScript.emptyDishesStarted == true){
            return true;
        }
        return false;
    }

    public bool checkEndOfCleanDishes(){
            if(emptyDishwasherScript.emptyDishesFinished == true){
                return true;
            }
            return false;
        }

//2 dirtydishes
public bool checkStartOfDirtyDishes(){
        if(fillDishwasherScript.fillDishesStarted == true){
            return true;
        }
        return false;
    }

    public bool checkEndOfDirtyDishes(){
            if(fillDishwasherScript.fillDishesFinished == true){
                return true;
            }
            return false;
        }
//3 sorting
// 4 serving
//5piling

//6 drawing




    public bool checkGameCompletion(){
        if(fillDishwasherScript.targetZoneFull 
        && emptyDishwasherScript.targetZoneFull
        && sortTaskScript.IsSortingCompleted()
        && drawTaskScript.IsDrawingCompleted()){
            return true;
        }
        return false;
    }

    void gameFinished(){
        Debug.Log("DEBUG: TASKS COMPLETED");
//show some ui element
    }
}
