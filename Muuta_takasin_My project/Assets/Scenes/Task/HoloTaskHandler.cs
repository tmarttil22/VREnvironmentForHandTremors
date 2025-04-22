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

    public GameObject taskCompletionObject;
    private TaskCompletionHandler taskCompletionHandler;

    private bool taskCompleted = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        taskCompletionHandler = taskCompletionObject.GetComponent<TaskCompletionHandler>();

        mugHoloChecker = mugHolo.GetComponent<HologramChecker>();
        potHoloChecker = potHolo.GetComponent<HologramChecker>();
        plateHoloChecker = plateHolo.GetComponent<HologramChecker>();
        bowlHoloChecker = bowlHolo.GetComponent<HologramChecker>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!taskCompleted) {
            if (mugHoloChecker.GetIsInside()
            && potHoloChecker.GetIsInside()
            && plateHoloChecker.GetIsInside()
            && bowlHoloChecker.GetIsInside()) {
                taskCompleted = true;
                taskCompletionHandler.SetAsCompleted();
            }
        }
    }
}
