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
    public GameObject platform6;
    private SortHandler sortHandler6;
    public GameObject platform7;
    private SortHandler sortHandler7;

    private SortHandler[] sortHandlers;

    public int totalCount = 7;
    private int correctCount = 0;
    private bool sortingCompleted = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        taskCompletionHandler = taskCompletionObject.GetComponent<TaskCompletionHandler>();

        sortHandlers = new SortHandler[totalCount];
        sortHandlers[0] = platform1.GetComponent<SortHandler>();
        sortHandlers[1] = platform2.GetComponent<SortHandler>();
        sortHandlers[2] = platform3.GetComponent<SortHandler>();
        sortHandlers[3] = platform4.GetComponent<SortHandler>();
        sortHandlers[4] = platform5.GetComponent<SortHandler>();
        sortHandlers[5] = platform6.GetComponent<SortHandler>();
        sortHandlers[6] = platform7.GetComponent<SortHandler>();
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

        if (correctCount == totalCount) {
            taskCompletionHandler.SetAsCompleted();

            SetSortingCompleted();
        }
    }

    public int GetCorrectCount() {
        return correctCount;
    }

    private void SetSortingCompleted() {
        sortingCompleted = true;
    }

    public bool IsSortingCompleted() {
        return sortingCompleted;
    }
}
