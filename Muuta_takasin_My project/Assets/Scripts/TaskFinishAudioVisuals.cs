using TMPro;
using UnityEngine;

public class TaskFinishedAudioVisuals : MonoBehaviour
{
    [Header("Textfields")]
    public TextMeshProUGUI servingItems;
    public TextMeshProUGUI drawing;
    public TextMeshProUGUI serving;
    public TextMeshProUGUI stacking;
    public TextMeshProUGUI stackingNum;
    public TextMeshProUGUI sorting;
    public TextMeshProUGUI sortingNum;
    public TextMeshProUGUI kitchenSink;
    public TextMeshProUGUI kitchenSinkNum;
    public TextMeshProUGUI dishwasher;
    public TextMeshProUGUI dishwasherNum;

    [Header("Tasks")]
    public GameObject tableSetObject;
    private TaskCompletionHandler tableSetHandler;

    public GameObject sortingObject;
    private TaskCompletionHandler sortingHandler;

    public GameObject drawingObject;
    private TaskCompletionHandler drawingHandler;

    public GameObject stackingObject;
    private TaskCompletionHandler stackingHandler;

    public GameObject emptyDishWasherObject;
    private TaskCompletionHandler emptyDishWasherHandler;

    public GameObject fillDishWasherObject;
    private TaskCompletionHandler fillDishWasherHandler;

    private bool tableSetFlag = false;
    private bool sortFlag = false;
    private bool drawingFlag = false;
    private bool stackingFlag = false;
    private bool emptyDishWasherFlag = false;
    private bool fillDishWasherFlag = false;
    
    AudioSource taskCompletedSound;

    void Start()
    {
        tableSetHandler = tableSetObject.GetComponent<TaskCompletionHandler>();
        sortingHandler = sortingObject.GetComponent<TaskCompletionHandler>();
        drawingHandler = drawingObject.GetComponent<TaskCompletionHandler>();
        stackingHandler = stackingObject.GetComponent<TaskCompletionHandler>();
        emptyDishWasherHandler = emptyDishWasherObject.GetComponent<TaskCompletionHandler>();
        fillDishWasherHandler = fillDishWasherObject.GetComponent<TaskCompletionHandler>();

        taskCompletedSound = GetComponent<AudioSource>();

        // Optimization: Using this to avoid checking every frame, and checking every 0.75 seconds instead
        InvokeRepeating("CheckCompletion", 15.0f, 0.75f);
    }

    // Update is called once per frame
    void CheckCompletion()
    {
        if (tableSetHandler.GetIsCompleted() && !tableSetFlag) {
            serving.color = Color.green;
            servingItems.color = Color.green;
            tableSetFlag = true;

            taskCompletedSound.Play();
        }

        if (sortingHandler.GetIsCompleted() && !sortFlag) {
            sorting.color = Color.green;
            sortingNum.color = Color.green;
            sortFlag = true;
            
            taskCompletedSound.Play();
        }

        if (drawingHandler.GetIsCompleted() && !drawingFlag) {
            drawing.color = Color.green;
            drawingFlag = true;
            
            taskCompletedSound.Play();
        }

        if (stackingHandler.GetIsCompleted() && !stackingFlag) {
            stacking.color = Color.green;
            stackingNum.color = Color.green;
            stackingFlag = true;
            
            taskCompletedSound.Play();
        }

        if (emptyDishWasherHandler.GetIsCompleted() && !emptyDishWasherFlag) {
            dishwasher.color = Color.green;
            dishwasherNum.color = Color.green;
            emptyDishWasherFlag = true;
            
            taskCompletedSound.Play();
        }

        if (fillDishWasherHandler.GetIsCompleted() && !fillDishWasherFlag) {
            kitchenSink.color = Color.green;
            kitchenSinkNum.color = Color.green;
            fillDishWasherFlag = true;
            
            taskCompletedSound.Play();
        }
    }
}
