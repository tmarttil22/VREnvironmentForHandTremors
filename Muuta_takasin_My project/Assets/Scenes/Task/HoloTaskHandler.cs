using UnityEngine;

public class HoloTaskHandler : MonoBehaviour
{
    public GameObject mugHolo;
    private HologramChecker mugHoloChecker;
    public GameObject potHolo;
    private HologramChecker potHoloChecker;
    public GameObject plateHolo;
    private HologramChecker plateHoloChecker;
    public GameObject bowlHolo;
    private HologramChecker bowlHoloChecker;
    public GameObject breadHolo;
    private HologramChecker breadHoloChecker;
    public GameObject milkHolo;
    private HologramChecker milkHoloChecker;
    public GameObject ketchupHolo;
    private HologramChecker ketchupHoloChecker;
    public GameObject mustardHolo;
    private HologramChecker mustardHoloChecker;

    public GameObject taskCompletionObject;
    private TaskCompletionHandler taskCompletionHandler;

    private bool taskStarted = false;
    private bool taskCompleted = false;
    private float startTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        taskCompletionHandler = taskCompletionObject.GetComponent<TaskCompletionHandler>();

        mugHoloChecker = mugHolo.GetComponent<HologramChecker>();
        potHoloChecker = potHolo.GetComponent<HologramChecker>();
        plateHoloChecker = plateHolo.GetComponent<HologramChecker>();
        bowlHoloChecker = bowlHolo.GetComponent<HologramChecker>();
        breadHoloChecker = breadHolo.GetComponent<HologramChecker>();
        milkHoloChecker = milkHolo.GetComponent<HologramChecker>();
        ketchupHoloChecker = ketchupHolo.GetComponent<HologramChecker>();
        mustardHoloChecker = mustardHolo.GetComponent<HologramChecker>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!taskStarted)
        {
            if (mugHoloChecker.GetIsInside()
            || potHoloChecker.GetIsInside()
            || plateHoloChecker.GetIsInside()
            || bowlHoloChecker.GetIsInside()
            || breadHoloChecker.GetIsInside()
            || milkHoloChecker.GetIsInside()
            || ketchupHoloChecker.GetIsInside()
            || mustardHoloChecker.GetIsInside())
            {
                taskStarted = true;
                startTime = Time.time;
            }
        }

        if (!taskCompleted)
        {
            if (mugHoloChecker.GetIsInside()
            && potHoloChecker.GetIsInside()
            && plateHoloChecker.GetIsInside()
            && bowlHoloChecker.GetIsInside()
            && breadHoloChecker.GetIsInside()
            && milkHoloChecker.GetIsInside()
            && ketchupHoloChecker.GetIsInside()
            && mustardHoloChecker.GetIsInside()
            )
            {
                taskCompleted = true;
                taskCompletionHandler.SetAsCompleted();
            }
        }
    }

    public bool IsServingStarted()
    {
        return taskStarted;
    }
    public bool IsServingCompleted()
    {
        if (taskCompleted)
        {
            return true;
        }

        if (taskStarted && Time.time - startTime > 120)
        {
            taskCompleted = true;
            Debug.Log("Time ran out");
        }
        return taskCompleted;
    }
}
