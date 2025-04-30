using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ControllerDataLogger : MonoBehaviour
{
    public string controllerSide = "Right"; // Set to "Left" or "Right" in Inspector

    private class LogEntry
    {
        public double timestamp;
        public string controller_side;
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

    void Start()
    {
        string path = Application.dataPath + "/Log/";
        fileName = $"{fileName}_{controllerSide}_{DateTime.UtcNow:yyyyMMdd_HHmmss}.csv";
        filePath = path + fileName;
    }

    void Update()
    {
        // Record data
        Vector3 pos = transform.position;
        Vector3 rot = transform.eulerAngles;
        double timeInS = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

        buffer.Add(new LogEntry
        {
            timestamp = timeInS,
            controller_side = controllerSide,
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
            if (writeHeader)
            {
                writer.WriteLine("timestamp,controller_side,position_x,position_y,position_z,rotation_x,rotation_y,rotation_z");
                fileInitialized = true;
            }

            foreach (var entry in buffer)
            {
                writer.WriteLine($"{entry.timestamp},{entry.controller_side},{entry.position_x},{entry.position_y},{entry.position_z},{entry.rotation_x},{entry.rotation_y},{entry.rotation_z}");
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
