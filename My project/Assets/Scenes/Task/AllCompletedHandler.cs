using UnityEngine;
using TMPro;


public class AllCompletedHandler : MonoBehaviour
{
    public GameObject tableSetObject;
    private TaskCompletionHandler tableSetHandler;

    public GameObject sortingObject;
    private TaskCompletionHandler sortingHandler;

    public GameObject drawingObject;
    private TaskCompletionHandler drawingHandler;

    public GameObject stackingObject;
    private TaskCompletionHandler stackingHandler;

    private TextMeshProUGUI text;

    private bool isCompleted = false;

    public string setText = "RENAME_THIS";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tableSetHandler = tableSetObject.GetComponent<TaskCompletionHandler>();
        sortingHandler = sortingObject.GetComponent<TaskCompletionHandler>();
        drawingHandler = drawingObject.GetComponent<TaskCompletionHandler>();
        stackingHandler = stackingObject.GetComponent<TaskCompletionHandler>();

        text = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isCompleted) {
            if (tableSetHandler.GetIsCompleted()
            && sortingHandler.GetIsCompleted()
            && drawingHandler.GetIsCompleted()
            && stackingHandler.GetIsCompleted())
            {
                SetAsCompleted();
            }
        }
    }

    private void SetAsCompleted () {
        isCompleted = true;
        text.text = string.Format(setText);
    }
}
