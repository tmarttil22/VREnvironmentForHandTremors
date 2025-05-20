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

    //1 cleansdishes
    public bool checkStartOfCleanDishes()
    {
        if (emptyDishwasherScript.emptyDishesStarted == true)
        {
            return true;
        }
        return false;
    }

    public bool checkEndOfCleanDishes()
    {
        if (emptyDishwasherScript.emptyDishesFinished == true)
        {
            return true;
        }
        return false;
    }

    //2 dirtydishes
    public bool checkStartOfDirtyDishes()
    {
        if (fillDishwasherScript.fillDishesStarted == true)
        {
            return true;
        }
        return false;
    }

    public bool checkEndOfDirtyDishes()
    {
        if (fillDishwasherScript.fillDishesFinished == true)
        {
            return true;
        }
        return false;
    }

    //3 sorting
    public bool checkStartOfSorting()
    {
        return sortTaskScript.IsSortingStarted();
    }

    public bool checkEndOfSorting()
    {
        return sortTaskScript.IsSortingCompleted();
    }

    // 4 serving
    public bool checkStartOfServing()
    {
        return serveTaskScript.IsServingStarted();
    }

    public bool checkEndOfServing()
    {
        return serveTaskScript.IsServingCompleted();
    }

    //5 drawing
    public bool checkStartOfDrawing()
    {
        return drawTaskScript.IsDrawingStarted();
    }

    public bool checkEndOfDrawing()
    {
        return drawTaskScript.IsDrawingCompleted();
    }




    public bool checkGameCompletion()
    {
        if (checkEndOfDirtyDishes()
        && checkEndOfCleanDishes()
        && checkEndOfSorting()
        && checkEndOfDrawing()
        && checkEndOfServing()
        )
        {
            return true;
        }
        return false;
    }

    void gameFinished() {
        Debug.Log("DEBUG: TASKS COMPLETED");
        //show some ui element or play sound?
        //save data and stuff?
    }
}
