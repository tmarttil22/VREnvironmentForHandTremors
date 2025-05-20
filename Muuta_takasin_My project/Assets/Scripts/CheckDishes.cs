using System;
using Unity.VisualScripting;
using UnityEngine;

public class CheckDishes : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject targetZone;

    private TaskCompletionHandler taskCompletionHandler;
    //private TaskStartChecker taskStartChecker;
    public GameObject taskCompletionObject;
    public bool targetZoneFull;

    private int plateCount;
    private int mugCount;
    public int targetMugCount;
    public int targetPlateCount;
    public bool emptyDishesStarted;
    public bool emptyDishesFinished;
    bool hasStarted;

    public TaskStartChecker plate1;
    public TaskStartChecker plate2;
    public TaskStartChecker plate3;
    public TaskStartChecker plate4;
    public TaskStartChecker plate5;
    public TaskStartChecker plate6;
    public TaskStartChecker mug1;
    public TaskStartChecker mug2;
    public TaskStartChecker mug3;

    float startTime;
    float endTime;

    void Start()
    {
        hasStarted = false;
        taskCompletionHandler = taskCompletionObject.GetComponent<TaskCompletionHandler>(); 
        plateCount = 0;
        mugCount = 0;
        targetZoneFull = false;
    }

    // Update is called once per frame
    void Update()
    {   
        CheckStart();
        CheckCompletion();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "PlateD")
        {
            plateCount++ ;
        }
        else if (other.gameObject.name == "MugD"){
            mugCount++;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "PlateD")
        {
            plateCount-- ;
        }
        else if (other.gameObject.name == "MugD"){
            mugCount--;
        }
    }

    public bool CheckStart(){
        if(hasStarted){
            return true; //if flagged as started then return
        }
        else if( // if not flagged, lets check 
            plate1.objectHasMoved||plate2.objectHasMoved
          ||plate3.objectHasMoved||plate4.objectHasMoved
          ||plate5.objectHasMoved||plate6.objectHasMoved
          ||mug1.objectHasMoved||mug2.objectHasMoved||mug3.objectHasMoved){
            hasStarted = true;
            emptyDishesStarted = true;
            startTime = Time.time;
            return true;
          }
            return false;
        }
    

    public void CheckCompletion(){
        if (plateCount == targetPlateCount && mugCount == targetMugCount){
            targetZoneFull = true;
            emptyDishesFinished = true;
            taskCompletionHandler.SetAsCompleted();
            //Debug.Log("Task finished");
        }else if (Time.time-startTime>120){//2 minutes has passed, ,move on 
            targetZoneFull = true;
            emptyDishesFinished = true;
            taskCompletionHandler.SetAsCompleted();
            Debug.Log("Time ran out");
        }
        else{
            targetZoneFull = false;
        }
    }
    public int checkProgress(){
        return plateCount+mugCount;
    }
}
