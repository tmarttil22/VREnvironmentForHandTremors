using UnityEngine;

public class CheckDrawings : MonoBehaviour
{
    private bool drawingStarted = false;
    private bool drawingCompleted = false;
    private float startTime;

    public Whiteboard squareDrawing;
    public Whiteboard circleDrawing;
    public Whiteboard starDrawing;
    public Whiteboard finalDrawing;
    public WhiteboardMarker marker;
    public TaskCompletionHandler taskCompletionHandler;
    private string currentDrawingName = "";
    private string lastDrawingName = "";
    private string drawingName = "";

    private bool drawingStateChanged = false;
    private string drawingState = "";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!drawingStarted)
        {
            if (squareDrawing.IsTouched()
            || circleDrawing.IsTouched()
            || starDrawing.IsTouched()
            || finalDrawing.IsTouched())
            {
                drawingStarted = true;
                startTime = Time.time;
            }
        }

        if (!drawingCompleted)
        {
            currentDrawingName = marker.GetCurrentDrawingName();

            drawingStateChanged = (lastDrawingName != currentDrawingName);

            if (drawingStateChanged)
            {
                if (lastDrawingName == "")
                {
                    drawingState = " start";
                    drawingName = currentDrawingName;
                }
                else if (currentDrawingName == "")
                {
                    drawingState = " end";
                    drawingName = lastDrawingName;
                }
            }

            if (squareDrawing.IsTouched()
            && circleDrawing.IsTouched()
            && starDrawing.IsTouched()
            && finalDrawing.IsTouched()
            )
            {
                drawingCompleted = true;
                taskCompletionHandler.SetAsCompleted();
            }

            lastDrawingName = currentDrawingName;
        }
    }

    public bool IsDrawingStarted()
    {
        return drawingStarted;
    }

    public bool IsDrawingCompleted()
    {
        if (drawingCompleted)
        {
            return true;
        }

        if (drawingStarted && Time.time - startTime > 120)
        {
            drawingCompleted = true;
            taskCompletionHandler.SetAsCompleted();

            Debug.Log("Time ran out");
        }
        return drawingCompleted;
    }

    public string GetCurrentDrawingState()
    {
        if (!drawingStateChanged)
        {
            return "";
        }
        return drawingName + drawingState;
    }

    public bool HasDrawingStateChanged() {
        return drawingStateChanged;
    }
}
