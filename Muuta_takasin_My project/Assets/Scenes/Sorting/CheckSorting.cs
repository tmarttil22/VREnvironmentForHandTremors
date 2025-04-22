using UnityEngine;

public class CheckSorting : MonoBehaviour
{
    public GameObject taskCompletionObject;
    private TaskCompletionHandler taskCompletionHandler;
    public GameObject platform1;
    private SortHandler sortHandler1;
    public GameObject platform2;
    private SortHandler sortHandler2;
    public GameObject platform3;
    private SortHandler sortHandler3;
    public GameObject platform4;
    private SortHandler sortHandler4;
    public GameObject platform5;
    private SortHandler sortHandler5;

    private SortHandler[] sortHandlers;

    private int correctCount = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        taskCompletionHandler = taskCompletionObject.GetComponent<TaskCompletionHandler>();

        sortHandlers = new SortHandler[5];
        sortHandlers[0] = platform1.GetComponent<SortHandler>();
        sortHandlers[1] = platform2.GetComponent<SortHandler>();
        sortHandlers[2] = platform3.GetComponent<SortHandler>();
        sortHandlers[3] = platform4.GetComponent<SortHandler>();
        sortHandlers[4] = platform5.GetComponent<SortHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        correctCount = 0;

        foreach (SortHandler sort in sortHandlers) {
            if (sort.GetIsCorrect()) {
                correctCount++;
            }
        }

        if (correctCount == 5) {
            taskCompletionHandler.SetAsCompleted();
        }
    }

    public int GetCorrectCount() {
        return correctCount;
    }
}
