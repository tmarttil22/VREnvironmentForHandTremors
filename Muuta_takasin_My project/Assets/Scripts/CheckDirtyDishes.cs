using UnityEngine;

public class CheckDirtyDishes : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject targetZone;

    private TaskCompletionHandler taskCompletionHandler;
    public GameObject taskCompletionObject;
    public bool targetZoneFull;

    private int plateCount;
    private int mugCount;
    public int targetMugCount;
    public int targetPlateCount;
    public  bool hasStarted;
    public bool isFinished;
    public bool fillDishesStarted;
    public bool fillDishesFinished;

    public TaskStartChecker plate1;
    public TaskStartChecker plate2;
    public TaskStartChecker plate3;
    public TaskStartChecker plate4;

    public float startTime;

    void Start()
    {
        taskCompletionHandler = taskCompletionObject.GetComponent<TaskCompletionHandler>();
        plateCount = 0;
        mugCount = 0;
        targetZoneFull = false;
        hasStarted = false;
        isFinished = false;
        fillDishesStarted= false;
        fillDishesFinished= false;
        
    }

    // Update is called once per frame
    void Update()
    {   
        CheckStart();
        CheckCompletion();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "PlateDirty")
        {
            plateCount++ ;

        }
        else if (other.gameObject.name == "MugDirty"){
            mugCount++;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "PlateDirty")
        {
            plateCount-- ;
        }
        else if (other.gameObject.name == "MugDirty"){
            mugCount--;
        }
    }

public bool CheckStart(){
        if(hasStarted){
            return true; //if flagged as started then return
        }
        else if( // if not flagged, lets check 
            plate1.objectHasMoved||plate2.objectHasMoved
          ||plate3.objectHasMoved||plate4.objectHasMoved){
            hasStarted = true;
            fillDishesStarted = true;
            startTime = Time.time;
            return true;
          }
            return false;
        }

    public void CheckCompletion(){
        if (plateCount == targetPlateCount && mugCount == targetMugCount){
            targetZoneFull = true;
            fillDishesFinished = true;
            taskCompletionHandler.SetAsCompleted();
        }else if (Time.time-startTime>120){//2 minutes has passed, ,move on 
            targetZoneFull = true;
            fillDishesFinished = true;
            taskCompletionHandler.SetAsCompleted();
            Debug.Log("Time ran out");
        }else{
            targetZoneFull = false;
        }
    }
    public int checkProgress(){
        return plateCount+mugCount;
    }

    
}
