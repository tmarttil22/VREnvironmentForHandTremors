using UnityEngine;

public class CheckDrawings : MonoBehaviour
{
    private bool drawingCompleted = false;

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

    public bool IsDrawingCompleted() {
        return drawingCompleted;
    }
}
