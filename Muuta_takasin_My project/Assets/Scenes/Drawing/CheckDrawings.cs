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

            if (squareDrawing.IsTouched()
            && circleDrawing.IsTouched()
            && starDrawing.IsTouched()
            && finalDrawing.IsTouched()
            )
            {
                drawingCompleted = true;
            }
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
            
            Debug.Log("Time ran out");
        }
        return drawingCompleted;
    }
    
}
