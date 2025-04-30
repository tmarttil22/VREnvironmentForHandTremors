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
    void Start()
    {
        taskCompletionHandler = taskCompletionObject.GetComponent<TaskCompletionHandler>();
        plateCount = 0;
        mugCount = 0;
        targetZoneFull = false;
    }

    // Update is called once per frame
    void Update()
    {
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
    public void CheckCompletion(){
        if (plateCount == targetPlateCount && mugCount == targetMugCount){
            targetZoneFull = true;
            taskCompletionHandler.SetAsCompleted();
        }else{
            targetZoneFull = false;
        }
    }
    public int checkProgress(){
        return plateCount+mugCount;
    }
}
