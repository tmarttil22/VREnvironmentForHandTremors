using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ControllerDataLogger : MonoBehaviour
{
    public string controllerSide = "Right"; // Set to "Left" or "Right" in Inspector

    private class LogEntry  //contains log entries for activities made in the unity vr simulation
    {
        public double timestamp;    
        public string controller_side_or_job_label; //string entry for log entry, can contain any log relevant string 
        public float position_x;
        public float position_y;
        public float position_z;
        public float rotation_x;
        public float rotation_y;
        public float rotation_z;
    }

    public string fileName = "Subject_";
    private List<LogEntry> buffer = new List<LogEntry>();
    private string filePath;
    private float flushInterval = 5f;  //flush the data every 5seconds
    private float timeSinceLastFlush = 0f;
    private bool fileInitialized = false;

//my modifications for XR movewment disorders - Akseli
    public ProgressTracker progressTracker;

    //1
    private bool cleanDishesStartedLogged;
    private bool cleanDishesFinishedLogged;   
    //2
    private bool dirtyDishesStartedLogged;
    private bool dirtyDishesFinishedLogged;
    //3
    private bool sortingStartedLogged;
    private bool sortingFinishedLogged;
    //4
    private bool servingStartedLogged;
    private bool servingFinishedLogged;
    //5
    private bool drawingStartedLogged;
    private bool drawingFinishedLogged;


    void Start()
    {
        string path = Application.dataPath + "/Log/";
        fileName = $"{fileName}_{controllerSide}_{DateTime.UtcNow:yyyyMMdd_HHmmss}.csv";
        filePath = path + fileName;

        // 1 - Clean Dishes
        cleanDishesStartedLogged = false;
        cleanDishesFinishedLogged = false;

        // 2 - Dirty Dishes
        dirtyDishesStartedLogged = false;
        dirtyDishesFinishedLogged = false;

        // 3 - Sorting
        sortingStartedLogged = false;
        sortingFinishedLogged = false;

        // 4 - Serving
        servingStartedLogged = false;
        servingFinishedLogged = false;

        // 5 - Drawing
        drawingStartedLogged = false;
        drawingFinishedLogged = false;

    }

    void Update()
    {
        // Record data
        Vector3 pos = transform.position;
        Vector3 rot = transform.eulerAngles;
        //double timeInS = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        double timeInS = Time.time;

        //check for job start and stop labels before writing positions 
        if (!cleanDishesStartedLogged && progressTracker.checkStartOfCleanDishes())
        {
            buffer.Add(new LogEntry{controller_side_or_job_label = "Empty dishwasher start"});
            cleanDishesStartedLogged = true;
        }
            if(!cleanDishesFinishedLogged &&progressTracker.checkEndOfCleanDishes()){
            buffer.Add(new LogEntry{controller_side_or_job_label = "Empty dishwasher end"});
            cleanDishesFinishedLogged = true;
        }
        //2
        if(!dirtyDishesStartedLogged &&progressTracker.checkStartOfDirtyDishes()){
            buffer.Add(new LogEntry{controller_side_or_job_label = "Fill dishwasher start"});
            dirtyDishesStartedLogged = true;
        }
            if(!dirtyDishesFinishedLogged &&progressTracker.checkEndOfDirtyDishes()){
            buffer.Add(new LogEntry{controller_side_or_job_label = "Fill dishwasher end"});
            dirtyDishesFinishedLogged = true;
        }

        //3
        if (!sortingStartedLogged && progressTracker.checkStartOfSorting())
        {
            buffer.Add(new LogEntry{controller_side_or_job_label = "Sorting start"});
            sortingStartedLogged = true;
        }
        
        if (!sortingFinishedLogged && progressTracker.checkEndOfSorting())
        {
            buffer.Add(new LogEntry{controller_side_or_job_label = "Sorting end"});
            sortingFinishedLogged = true;
        }

        //4
        if (!servingStartedLogged && progressTracker.checkStartOfServing())
        {
            buffer.Add(new LogEntry{controller_side_or_job_label = "Serving start"});
            servingStartedLogged = true;
        }
        
        if (!servingFinishedLogged && progressTracker.checkEndOfServing())
        {
            buffer.Add(new LogEntry{controller_side_or_job_label = "Serving end"});
            servingFinishedLogged = true;
        }

        //5
        if (!drawingStartedLogged && progressTracker.checkStartOfDrawing())
        {
            buffer.Add(new LogEntry{controller_side_or_job_label = "Drawing start"});
            drawingStartedLogged = true;
        }
        
        if (!drawingFinishedLogged && progressTracker.checkEndOfDrawing())
        {
            buffer.Add(new LogEntry { controller_side_or_job_label = "Drawing end" });
            drawingFinishedLogged = true;
        }

        if (drawingStartedLogged && !drawingFinishedLogged)
        {
            //Log when individual drawing started and ended
            string drawingState = progressTracker.checkIndividualDrawingState();
            if (drawingState != "")
            {
                buffer.Add(new LogEntry { controller_side_or_job_label = drawingState });
            }
        }

      //labeling ends here



        buffer.Add(new LogEntry
        {
            timestamp = timeInS,
            controller_side_or_job_label = controllerSide,
            position_x = pos.x,
            position_y = pos.y,
            position_z = pos.z,
            rotation_x = rot.x,
            rotation_y = rot.y,
            rotation_z = rot.z
        });

        // Flush every 5 seconds
        timeSinceLastFlush += Time.deltaTime;
        if (timeSinceLastFlush >= flushInterval)
        {
            FlushBufferToFile();
            timeSinceLastFlush = 0f;
        }
    }

    void FlushBufferToFile()
    {
        bool writeHeader = !fileInitialized;
        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            //my modifications xr disorders -AA
            //1
            /*
            if (!cleanDishesStartedLogged && progressTracker.checkStartOfCleanDishes())
            {
                writer.WriteLine("Empty dishwasher start");
                cleanDishesStartedLogged = true;
            }
             if(!cleanDishesFinishedLogged &&progressTracker.checkEndOfCleanDishes()){
                writer.WriteLine("Empty dishwasher end");
                cleanDishesFinishedLogged = true;
            }
            //2
            if(!dirtyDishesStartedLogged &&progressTracker.checkStartOfDirtyDishes()){
                writer.WriteLine("Fill dishwasher start");
                dirtyDishesStartedLogged = true;
            }
             if(!dirtyDishesFinishedLogged &&progressTracker.checkEndOfDirtyDishes()){
                writer.WriteLine("Fill dishwasher end");
                dirtyDishesFinishedLogged = true;
            }

            //3
            if (!sortingStartedLogged && progressTracker.checkStartOfSorting())
            {
                writer.WriteLine("Sorting start");
                sortingStartedLogged = true;
            }
            
            if (!sortingFinishedLogged && progressTracker.checkEndOfSorting())
            {
                writer.WriteLine("Sorting end");
                sortingFinishedLogged = true;
            }

            //4
            if (!servingStartedLogged && progressTracker.checkStartOfServing())
            {
                writer.WriteLine("Serving start");
                servingStartedLogged = true;
            }
            
            if (!servingFinishedLogged && progressTracker.checkEndOfServing())
            {
                writer.WriteLine("Serving end");
                servingFinishedLogged = true;
            }

            //5
            if (!drawingStartedLogged && progressTracker.checkStartOfDrawing())
            {
                writer.WriteLine("Drawing start");
                drawingStartedLogged = true;
            }
            
            if (!drawingFinishedLogged && progressTracker.checkEndOfDrawing())
            {
                writer.WriteLine("Drawing end");
                drawingFinishedLogged = true;
            }

*/

            //////////////////////
            if (writeHeader)
            {
                writer.WriteLine("timestamp,controller_side_or_job_label,position_x,position_y,position_z,rotation_x,rotation_y,rotation_z");
                fileInitialized = true;
            }

            foreach (var entry in buffer)
            {
                writer.WriteLine($"{entry.timestamp},{entry.controller_side_or_job_label},{entry.position_x},{entry.position_y},{entry.position_z},{entry.rotation_x},{entry.rotation_y},{entry.rotation_z}");
            }
        }

        buffer.Clear();
        Debug.Log($"[{controllerSide}] Flushed data to file at: {DateTime.UtcNow:HH:mm:ss}");
    }

    void OnApplicationQuit()
    {
        FlushBufferToFile(); // Final save on quit
        Debug.Log($"[{controllerSide}] Final log saved to: {filePath}");
    }
}
